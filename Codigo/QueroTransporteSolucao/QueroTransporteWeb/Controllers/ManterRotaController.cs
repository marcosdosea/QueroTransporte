
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterRotaController : Controller
    {
        private readonly IGerenciadorRota _gerenciadorRota;

        public ManterRotaController(IGerenciadorRota gerenciadorRota)
        {
            _gerenciadorRota = gerenciadorRota;
        }

        public IActionResult Index()
        {
            return View(_gerenciadorRota.ObterTodos());
        }


        public IActionResult Create()
        { 
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ToSelectList(), "Id", "RotaComposta");
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorRota.Inserir(rotaModel);
                return RedirectToAction(nameof(Index));
            }

            return View(rotaModel);
        }


        public IActionResult Edit(int Id)
        {
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ToSelectList(), "Id", "RotaComposta");
            RotaModel rota = _gerenciadorRota.Buscar(Id);
            return View(rota);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorRota.Alterar(rotaModel);
                return RedirectToAction(nameof(Index));

            }
            return View(rotaModel);
        }

        public IActionResult Details(int Id)
        {
            RotaModel rotaModel = _gerenciadorRota.Buscar(Id);
            return View(rotaModel);
        }

        public IActionResult Delete(int Id)
        {
            RotaModel rotaModel = _gerenciadorRota.Buscar(Id);
            return View(rotaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, IFormCollection collection)
        {
            _gerenciadorRota.Excluir(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}