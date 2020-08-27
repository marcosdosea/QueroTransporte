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
            ViewBag.deferidas = TransacaoService.TransacaoUnityOfWork.TransacaoRepository.ObterTodasDeferidas(true).Count();
            ViewBag.indeferidas = TransacaoService.TransacaoUnityOfWork.TransacaoRepository.ObterTodasDeferidas(false).Count();
            return View();
        }

        public IActionResult HistoricoViagens()
        {
            ViewBag.realizada = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterTodosAbertos(true).Count();
            ViewBag.naoRealizada = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterTodosAbertos(false).Count();
            return View();
        }

        public IActionResult HistoricoSolicitacoes()
        {
            ViewBag.atendidas = SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.ObterTodosAtendidas(true).Count();
            ViewBag.naoAtendidas = SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.ObterTodosAtendidas(false).Count();
            return View();
        }
    }
}