using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using System;

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
        public IActionResult Index()
        {
            return View(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterTodos());
        }

        // GET: Frota/Details/5
        public IActionResult Details(int id)
        {
            return View(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterPorId(id));
        }

        // GET: Frota/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FrotaModel frota)
        {
            try
            {
                if (ModelState.IsValid && FrotaService.FrotaUnityOfWork.FrotaRepository.Inserir(frota))
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(frota);
            }
            return View(frota);
        }

        // GET: Frota/Edit/5
        public IActionResult Edit(int id)
        {
            return View(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterPorId(id));
        }

        // POST: Frota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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
        public IActionResult Delete(int id) => View(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterPorId(id));

        // POST: Frota/Delete/5
        public IActionResult Remove(int id)
        {
            try
            {
                if (FrotaService.FrotaUnityOfWork.FrotaRepository.Remover(id))
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), new { msg = "Erro" });
        }
    }
}