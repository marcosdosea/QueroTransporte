using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporteWeb.Resources.Methods;
using System;
using System.Security.Claims;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class PagarPassagemController : Controller
    {
        private readonly IPagarPassagemService PagarPassagemService;
        private readonly IViagemService ViagemService;
        private readonly IRotaService RotaService;
        private readonly ICreditoService CreditoService;
        private readonly IPagamentoService PagamentoService;
        private readonly ITransacaoService TransacaoService;

        public PagarPassagemController(IPagarPassagemService gerenciadorPagarPassagem, IViagemService gerenciadorViagem, IRotaService gerenciadorRota,
                                       ICreditoService gerenciadorCredito, IPagamentoService gerenciadorPagamento, ITransacaoService gerenciadorTransacao)
        {
            PagarPassagemService = gerenciadorPagarPassagem;
            ViagemService = gerenciadorViagem;
            RotaService = gerenciadorRota;
            CreditoService = gerenciadorCredito;
            PagamentoService = gerenciadorPagamento;
            TransacaoService = gerenciadorTransacao;
        }

        /// <summary>
        /// mostra as informacoes sobre a passagem
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Id usuario session
            var solicitacao = PagarPassagemService.PagamentoPassagemUnityOfWork.GerenciadorPagarPassagem.ObterViagemPorUsuarioData(
                MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity).Id, DateTime.Now);
            if (solicitacao != null)
            {
                var viagem = ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterPorId(solicitacao.IdViagem);
                var rota = RotaService.RotaUnityOfWork.GerenciadorRota.ObterPorId(viagem.IdRota);
                var creditos = CreditoService.CreditoUnityOfWork.GerenciadorComprarCredito.ObterPorId(solicitacao.IdUsuario);
                var viagemPassagem = new ViagemPassagemViewModel
                {
                    Viagem = viagem,
                    Solicitacao = solicitacao,
                    Rota = rota,
                    Creditos = creditos
                };
                return View(viagemPassagem);
            }
            else
            {
                return View();
            }

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
                    var creditosRestantes = (vP.Creditos.Saldo - (decimal)vP.Viagem.Preco);
                    vP.Creditos.Saldo = creditosRestantes;
                    CreditoService.CreditoUnityOfWork.GerenciadorComprarCredito.Editar(vP.Creditos);
                }
                else
                    pagamento.Tipo = 1;

                if (PagamentoService.PagamentoUnityOfWork.GerenciadorPagamento.Inserir(pagamento))
                {
                    TempData["mensagemSucesso"] = "Pagamento com crédito com sucesso.";

                    if (!TransacaoService.TransacaoUnityOfWork.GerenciadorTransacao.Inserir(addTransacao(vP, true)))
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