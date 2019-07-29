using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IGerenciadorUsuario _gerenciadorUsuario;

        public UsuarioController(IGerenciadorUsuario gerenciadorUsuario)
        {
            _gerenciadorUsuario = gerenciadorUsuario;
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View(_gerenciadorUsuario.ObterTodos());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            UsuarioModel usuario = _gerenciadorUsuario.Buscar(id);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            UsuarioModel user = new UsuarioModel();
            ViewBag.Tipos = new SelectList(_gerenciadorUsuario.GetTipos(), "string");
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorUsuario.Inserir(usuarioModel);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioModel user = new UsuarioModel();
            user = _gerenciadorUsuario.Buscar(id);
            ViewBag.Tipos = new SelectList(_gerenciadorUsuario.GetTipos(), "string");
            return View(user);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorUsuario.Alterar(usuarioModel);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _gerenciadorUsuario.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}