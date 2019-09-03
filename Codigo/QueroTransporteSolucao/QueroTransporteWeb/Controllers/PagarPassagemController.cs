﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using Model.ViewModel;
using QueroTransporte.Negocio;
using Business;

namespace QueroTransporteWeb.Controllers
{
    public class PagarPassagemController : Controller
    {
        private readonly GerenciadorPagarPassagem _gerenciadorPagarPassagem;
        private readonly GerenciadorViagem _gerenciadorViagem;
        private readonly GerenciadorRota _gerenciadorRota;
        private readonly GerenciadorComprarCredito _gerenciadorCredito;
        private readonly GerenciadorPagamento _gerenciadorPagamento;
        private readonly GerenciadorTransacao _gerenciadorTransacao;

        public PagarPassagemController(GerenciadorPagarPassagem gerenciadorPagarPassagem, GerenciadorViagem gerenciadorViagem, GerenciadorRota gerenciadorRota, 
                                       GerenciadorComprarCredito gerenciadorCredito, GerenciadorPagamento gerenciadorPagamento, GerenciadorTransacao gerenciadorTransacao)
        {
            _gerenciadorPagarPassagem = gerenciadorPagarPassagem;
            _gerenciadorViagem = gerenciadorViagem;
            _gerenciadorRota = gerenciadorRota;
            _gerenciadorCredito = gerenciadorCredito;
            _gerenciadorPagamento = gerenciadorPagamento;
            _gerenciadorTransacao = gerenciadorTransacao;
        }

        /// <summary>
        /// mostra as informacoes sobre a passagem
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Id usuario session
            var solicitacao = _gerenciadorPagarPassagem.ObterViagemPorUsuarioData(1, DateTime.Now);
            var viagem = _gerenciadorViagem.ObterPorId(solicitacao.IdViagem);
            var rota = _gerenciadorRota.ObterPorId(viagem.IdRota);
            var creditos = _gerenciadorCredito.ObterPorId(solicitacao.IdUsuario);
            var viagemPassagem = new ViagemPassagemViewModel
            {
                Viagem = viagem,
                Solicitacao = solicitacao,
                Rota = rota,
                Creditos = creditos
            };
            return View(viagemPassagem);
        }

        /// <summary>
        /// Pega os dados do pagamento e insere
        /// </summary>
        /// <param name="vP"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ViagemPassagemViewModel vP)
        {
            if (ModelState.IsValid)
            {
                var pagamento = new PagamentoPassagemModel();
                 pagamento.Data = DateTime.Now;
                if (vP.EhCredito)
                {
                    pagamento.Tipo = 2;
                    var creditosRestantes = (vP.Creditos.Saldo - (decimal) vP.Viagem.Preco);
                    vP.Creditos.Saldo = creditosRestantes;
                    _gerenciadorCredito.Editar(vP.Creditos);
                }
                else
                    pagamento.Tipo = 1;

                if (_gerenciadorPagamento.Inserir(pagamento))
                {
                    TempData["mensagemSucesso"] = "Pagamento com crédito com sucesso.";

                    if (!_gerenciadorTransacao.Inserir(addTransacao(vP, true)))
                        TempData["mensagemErroTransacao"] = "Houve um erro ao salvar esta transação no seu histórico";

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Houve um erro no pagamento, tente novamente";
                    return RedirectToAction("Index", "HomeController");
                }
                  
            }
                return View();
        }


        public TransacaoModel addTransacao(ViagemPassagemViewModel vp, bool deferido)
        {
            TransacaoModel tm = new TransacaoModel();
            tm.Data = DateTime.Now;
            tm.Deferido = deferido;
            tm.IdUsuario = vp.Creditos.IdUsuario;
            tm.QtdCreditos = vp.Creditos.Saldo;
            tm.Valor = vp.Creditos.Saldo;
            if (deferido)
                tm.Status = "Aprovado";
            else
                tm.Status = "Cancelada";
            tm.Tipo = "PAGAMENTO DE PASSAGEM";

            return tm;
        }
    }
}