using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class FrotaController : Controller
    {
        private readonly IFrotaService FrotaService;
        public FrotaController(IFrotaService frotaService)
        {
            FrotaService = frotaService;
        }
        // GET: Frota
        public ActionResult Index()
        {
            return View(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterTodos());
        }

        // GET: Frota/Details/5
        public ActionResult Details(int id)
        {
            return View(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterPorId(id));
        }

        // GET: Frota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Frota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FrotaModel frota)
        {
            try
            {
                if (ModelState.IsValid)
                    if (FrotaService.FrotaUnityOfWork.GerenciadorFrota.Inserir(frota))
                        return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(frota);
            }
            return View(frota);
        }

        // GET: Frota/Edit/5
        public ActionResult Edit(int id)
        {
            return View(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterPorId(id));
        }

        // POST: Frota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Frota/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterPorId(id));
        }

        // POST: Frota/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}