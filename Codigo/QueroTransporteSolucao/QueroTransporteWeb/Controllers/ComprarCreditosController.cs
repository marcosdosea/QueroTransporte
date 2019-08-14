using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using QueroTransporte.Model;

namespace QueroTransporteWeb.Controllers
{
    public class ComprarCreditosController : Controller
    {  
        public IActionResult Index()
        {
            ViewBag.Creditos = addListaCreditos();
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreditoViagemModel cv)
        {
            
            ViewBag.Creditos = addListaCreditos();
            if (ModelState.IsValid)
            {
                 return RedirectToAction(nameof(Index));
            }
            return View();
        }

        /// <summary>
        /// Metodo adiciona valores de creditos para comprar(esses dados devem vir do banco)
        /// </summary>
        public List<CreditoViagemViewModel> addListaCreditos()
        {
            List<CreditoViagemViewModel> creditoViagem = new List<CreditoViagemViewModel>();

            creditoViagem.Add(new CreditoViagemViewModel(1, "5 Creditos Para Viagem", 5.00));
            creditoViagem.Add(new CreditoViagemViewModel(2, "10 Creditos Para Viagem", 10.00));
            creditoViagem.Add(new CreditoViagemViewModel(3, "15 Creditos Para Viagem", 15.00));

            return creditoViagem;
        }
    }
}