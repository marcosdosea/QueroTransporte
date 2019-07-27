
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

        public ManterRotaController(IGerenciadorRota GerenciadorRota)
        {
            _gerenciadorRota = GerenciadorRota;
        }

        public IActionResult Index()
        {
            return View(_gerenciadorRota.ObterTodos());
        }


        public IActionResult Create()
        { 
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RotaModel Rota)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorRota.Inserir(Rota);
                return RedirectToAction(nameof(Index));
            }

            return View(Rota);
        }


        public IActionResult Edit(int Id)
        {
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            RotaModel Rota = _gerenciadorRota.Buscar(Id);
            ViewBag.Checked = Rota.IsComposta;
            return View(Rota);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, RotaModel Rota)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorRota.Alterar(Rota);
                return RedirectToAction(nameof(Index));

            }
            return View(Rota);
        }

        public IActionResult Details(int Id)
        {
            RotaModel Rota = _gerenciadorRota.Buscar(Id);

            if (Rota.RotaId != null)
                ViewBag.DetalhesRota = _gerenciadorRota.ObterDetalhesRota((int)Rota.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(Rota);
        }

        public IActionResult Delete(int Id)
        {
            RotaModel Rota = _gerenciadorRota.Buscar(Id);

            if (Rota.RotaId != null)
                ViewBag.DetalhesRota = _gerenciadorRota.ObterDetalhesRota((int) Rota.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(Rota);
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