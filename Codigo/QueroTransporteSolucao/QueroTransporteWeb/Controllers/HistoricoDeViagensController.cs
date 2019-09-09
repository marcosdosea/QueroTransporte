using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporteWeb.Controllers
{

    public class HistoricoDeViagensController : Controller
    {

        private readonly GerenciadorViagem _gerenciadorViagem;

        public HistoricoDeViagensController(GerenciadorViagem gerenciadorViagem)
        {
            _gerenciadorViagem = gerenciadorViagem;
        }

        public IActionResult Index()
        {
            return View(_gerenciadorViagem.ObterTodos());
        }

        public IActionResult Details(int id)
        {
            ViagemModel viagem = _gerenciadorViagem.ObterPorId(id);
            return View(viagem);
        }
    }
}