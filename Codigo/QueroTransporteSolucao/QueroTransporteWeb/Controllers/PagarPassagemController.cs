using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using Model.ViewModel;
namespace QueroTransporteWeb.Controllers
{
    public class PagarPassagemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(ViagemPassagemViewModel passagemView)
        {
            return View();
        }
    }
}