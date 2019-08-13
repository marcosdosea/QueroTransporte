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
        public IActionResult Index()
        {
            var cv =  new List<CreditoViagemViewModel>();

            cv.Add(new CreditoViagemViewModel(1,"Creditos de 5", 5.00));
            cv.Add(new CreditoViagemViewModel(2, "Creditos de 10", 10.00));
            cv.Add(new CreditoViagemViewModel(3, "Creditos de 15", 15.00));

            
            return View(cv);
        }
    }
}