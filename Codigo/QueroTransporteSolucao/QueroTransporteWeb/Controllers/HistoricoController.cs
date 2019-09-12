using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Negocio;
using System.Linq;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class HistoricoController : Controller
    {
        private readonly GerenciadorTransacao _gerenciadorTransacao;
        private readonly GerenciadorViagem _gerenciadorViagem;
        private readonly GerenciadorSolicitacao _gerenciadorSolicitacao;
        public HistoricoController(GerenciadorTransacao gerenciadorTransacao, GerenciadorViagem gerenciadorViagem, GerenciadorSolicitacao gerenciadorSolicitacao)
        {
            _gerenciadorSolicitacao = gerenciadorSolicitacao;
            _gerenciadorViagem = gerenciadorViagem;
            _gerenciadorTransacao = gerenciadorTransacao;
        }
        public IActionResult HistoricoTransacoes()
        {
            ViewBag.deferidas = _gerenciadorTransacao.ObterTodasDeferidas(true).Count();
            ViewBag.indeferidas = _gerenciadorTransacao.ObterTodasDeferidas(false).Count();
            return View();
        }

        public IActionResult HistoricoViagens()
        {
            ViewBag.realizada = _gerenciadorViagem.ObterTodosAbertos(true).Count();
            ViewBag.naoRealizada = _gerenciadorViagem.ObterTodosAbertos(false).Count();
            return View();
        }

        public IActionResult HistoricoSolicitacoes()
        {
            ViewBag.atendidas = _gerenciadorSolicitacao.ObterTodosAtendidas(true).Count();
            ViewBag.naoAtendidas = _gerenciadorSolicitacao.ObterTodosAtendidas(false).Count();
            return View();
        }
    }
}