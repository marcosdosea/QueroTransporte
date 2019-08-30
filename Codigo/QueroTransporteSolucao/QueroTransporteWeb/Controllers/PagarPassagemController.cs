using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using System;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class PagarPassagemController : Controller
    {
        private readonly GerenciadorPagarPassagem _gerenciadorPagarPassagem;
        private readonly GerenciadorViagem _gerenciadorViagem;
        private readonly GerenciadorRota _gerenciadorRota;
        private readonly GerenciadorComprarCredito _gerenciadorCredito;
        private readonly GerenciadorPagamento _gerenciadorPagamento;
        public PagarPassagemController(GerenciadorPagarPassagem gerenciadorPagarPassagem, GerenciadorViagem gerenciadorViagem, GerenciadorRota gerenciadorRota,
                                       GerenciadorComprarCredito gerenciadorCredito, GerenciadorPagamento gerenciadorPagamento)
        {
            _gerenciadorPagarPassagem = gerenciadorPagarPassagem;
            _gerenciadorViagem = gerenciadorViagem;
            _gerenciadorRota = gerenciadorRota;
            _gerenciadorCredito = gerenciadorCredito;
            _gerenciadorPagamento = gerenciadorPagamento;
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
                    var creditosRestantes = (vP.Creditos.Saldo - (decimal)vP.Viagem.Preco);
                    vP.Creditos.Saldo = creditosRestantes;
                    _gerenciadorCredito.Editar(vP.Creditos);
                }
                else
                    pagamento.Tipo = 1;

                if (_gerenciadorPagamento.Inserir(pagamento))
                {
                    TempData["mensagemSucesso"] = "Pagamento com crédito com sucesso.";
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
    }
}