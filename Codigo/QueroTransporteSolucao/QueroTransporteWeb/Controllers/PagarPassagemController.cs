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
        public PagarPassagemController(GerenciadorPagarPassagem gerenciadorPagarPassagem, GerenciadorViagem gerenciadorViagem, GerenciadorRota gerenciadorRota)
        {
            _gerenciadorPagarPassagem = gerenciadorPagarPassagem;
            _gerenciadorViagem = gerenciadorViagem;
            _gerenciadorRota = gerenciadorRota;
        }
        public IActionResult Index()
        {
            //Id usuario session
            var solicitacao = _gerenciadorPagarPassagem.ObterViagemPorUsuarioData(1, DateTime.Now);
            var viagem = _gerenciadorViagem.ObterPorId(solicitacao.IdViagem);
            var rota = _gerenciadorRota.ObterPorId(viagem.IdRota);
            var viagemPassagem = new ViagemPassagemViewModel
            {
                Viagem = viagem,
                Solicitacao = solicitacao,
                Rota = rota
            };
            return View();
        }

        public IActionResult Index(ViagemPassagemViewModel passagemView)
        {
            return View();
        }
    }
}