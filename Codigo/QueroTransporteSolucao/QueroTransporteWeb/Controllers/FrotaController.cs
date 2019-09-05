using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class FrotaController : Controller
    {
        private readonly GerenciadorFrota _gerenciadorFrota;
        public FrotaController(GerenciadorFrota gerenciadorFrota)
        {
            _gerenciadorFrota = gerenciadorFrota;
        }
        // GET: Frota
        public ActionResult Index()
        {
            return View(_gerenciadorFrota.ObterTodos());
        }

        // GET: Frota/Details/5
        public ActionResult Details(int id)
        {
            return View(_gerenciadorFrota.ObterPorId(id));
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
                    if (_gerenciadorFrota.Inserir(frota))
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
            return View(_gerenciadorFrota.ObterPorId(id));
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
            return View(_gerenciadorFrota.ObterPorId(id));
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