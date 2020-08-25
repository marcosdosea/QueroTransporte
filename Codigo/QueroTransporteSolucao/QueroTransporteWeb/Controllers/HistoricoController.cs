using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class HistoricoController : Controller
    {
        private readonly ITransacaoService TransacaoService;
        private readonly IViagemService ViagemService;
        private readonly ISolicitacaoService SolicitacaoService;
        public HistoricoController(ITransacaoService gerenciadorTransacao, IViagemService gerenciadorViagem, ISolicitacaoService gerenciadorSolicitacao)
        {
            SolicitacaoService = gerenciadorSolicitacao;
            ViagemService = gerenciadorViagem;
            TransacaoService = gerenciadorTransacao;
        }
        public IActionResult HistoricoTransacoes()
        {
            ViewBag.deferidas = TransacaoService.TransacaoUnityOfWork.GerenciadorTransacao.ObterTodasDeferidas(true).Count();
            ViewBag.indeferidas = TransacaoService.TransacaoUnityOfWork.GerenciadorTransacao.ObterTodasDeferidas(false).Count();
            return View();
        }

        public IActionResult HistoricoViagens()
        {
            ViewBag.realizada = ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterTodosAbertos(true).Count();
            ViewBag.naoRealizada = ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterTodosAbertos(false).Count();
            return View();
        }

        public IActionResult HistoricoSolicitacoes()
        {
            ViewBag.atendidas = SolicitacaoService.SolicitacaoUnityOfWork.GerenciadorSolicitacao.ObterTodosAtendidas(true).Count();
            ViewBag.naoAtendidas = SolicitacaoService.SolicitacaoUnityOfWork.GerenciadorSolicitacao.ObterTodosAtendidas(false).Count();
            return View();
        }
    }
}