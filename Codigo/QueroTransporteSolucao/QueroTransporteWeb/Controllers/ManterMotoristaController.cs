
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Negocio;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterMotoristaController : Controller
    {
        private readonly IGerenciadorMotorista _gerenciadorMotorista;
        private readonly IGerenciadorUsuario _gerenciadorUsuario;
        public ManterMotoristaController(IGerenciadorMotorista gerenciadorMotorista, IGerenciadorUsuario gerenciadorUsuario)
        {
            _gerenciadorMotorista = gerenciadorMotorista;
            _gerenciadorUsuario = gerenciadorUsuario;
        }

        public IActionResult Index()
        {
            ViewBag.NomeUsuarios = _gerenciadorUsuario.ObterUsuariosMotoristas();
            return View(_gerenciadorMotorista.ObterTodos());
        }

        public IActionResult Create()
        {
            ViewBag.UsuariosMotoristas = new SelectList(_gerenciadorUsuario.ObterUsuariosMotoristas(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorMotorista.Cadastrar(motorista);
                return RedirectToAction(nameof(Index));
            }

            return View(motorista);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.UsuariosMotoristas = new SelectList(_gerenciadorUsuario.ObterUsuariosMotoristas(), "Id", "Nome");
            MotoristaModel motorista = _gerenciadorMotorista.Buscar(id);
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorMotorista.Alterar(motorista);
                return RedirectToAction(nameof(Index));

            }
            return View(motorista);
        }

        // GET: Usuario/Details/5
        public IActionResult Details(int id)
        {
            MotoristaModel motorista = _gerenciadorMotorista.Buscar(id);
            ViewBag.NomeUsuario = _gerenciadorUsuario.Buscar(motorista.IdUsuario).Nome;
            return View(motorista);
        }
 
        public IActionResult Delete(int id)
        {
            MotoristaModel motorista = _gerenciadorMotorista.Buscar(id);
            ViewBag.NomeUsuario = _gerenciadorUsuario.Buscar(motorista.IdUsuario).Nome;
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _gerenciadorMotorista.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}