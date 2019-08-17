using System;
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
        public PagarPassagemController(GerenciadorPagarPassagem gerenciadorPagarPassagem, GerenciadorViagem gerenciadorViagem, GerenciadorRota gerenciadorRota, GerenciadorComprarCredito gerenciadorCredito)
        {
            _gerenciadorPagarPassagem = gerenciadorPagarPassagem;
            _gerenciadorViagem = gerenciadorViagem;
            _gerenciadorRota = gerenciadorRota;
            _gerenciadorCredito = gerenciadorCredito;
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(bool ehCredito)
        {

            return View();
        }
    }
}