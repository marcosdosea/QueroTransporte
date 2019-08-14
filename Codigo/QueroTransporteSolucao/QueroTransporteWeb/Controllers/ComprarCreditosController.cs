using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;

namespace QueroTransporteWeb.Controllers
{
    public class ComprarCreditosController : Controller
    {
        List<CreditoViagemViewModel> creditoViagem;

       

        public IActionResult Index()
        {
            addListaCreditos();
            return View(creditoViagem);
        }

        public IActionResult Comprar(int id)
        {
            addListaCreditos();
            return View(creditoViagem[id-1]);
        }

        /// <summary>
        /// Metodo adiciona valores de creditos para comprar(esses dados devem vir do banco)
        /// </summary>
        public void addListaCreditos()
        {
            creditoViagem = new List<CreditoViagemViewModel>();

            creditoViagem.Add(new CreditoViagemViewModel(1, "5 Creditos Para Viagem", 5.00));
            creditoViagem.Add(new CreditoViagemViewModel(2, "10 Creditos Para Viagem", 10.00));
            creditoViagem.Add(new CreditoViagemViewModel(3, "15 Creditos Para Viagem", 15.00));
        }
    }
}