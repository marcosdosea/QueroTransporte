
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using System.Collections.Generic;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize]
    public class MotoristaController : Controller
    {
        private readonly GerenciadorMotorista _gerenciadorMotorista;
        private readonly GerenciadorUsuario _gerenciadorUsuario;
        public MotoristaController(GerenciadorMotorista gerenciadorMotorista, GerenciadorUsuario gerenciadorUsuario)
        {
            _gerenciadorMotorista = gerenciadorMotorista;
            _gerenciadorUsuario = gerenciadorUsuario;
        }

        public IActionResult Index()
        {
            var listViewModel = new List<MotoristaUsuarioViewModel>();
            foreach (var motorista in _gerenciadorMotorista.ObterTodos())
            {
                var usuario = _gerenciadorUsuario.ObterPorId(motorista.IdUsuario);

                listViewModel.Add(new MotoristaUsuarioViewModel()
                {
                    Motorista = motorista,
                    Usuario = usuario
                });
            }
            return View(listViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.UsuariosMotoristas = new SelectList(_gerenciadorUsuario.ObterTodosUsuarios(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorMotorista.Inserir(motorista))
                    return RedirectToAction(nameof(Index));
                // TODO: Retornar uma mensagem ao usuario, caso tente cadastrar um motorista a um usuario já cadastrado.
                // Tipo: Motorista X = Usuario X => Motorista Y = Motorista X ... Isso quebra o banco e retorna o erro p a aplicação.
            }

            ViewBag.UsuariosMotoristas = new SelectList(_gerenciadorUsuario.ObterUsuariosMotoristas(), "Id", "Nome");
            return View(motorista);
        }
        public IActionResult Edit(int id)
        {
            var motorista = _gerenciadorMotorista.ObterPorId(id);
            return View(new MotoristaUsuarioViewModel { Motorista = motorista, Usuario = _gerenciadorUsuario.ObterPorId(motorista.IdUsuario) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorMotorista.Alterar(motorista))
                    return RedirectToAction(nameof(Index));

            }
            return View(motorista);
        }

        // GET: Usuario/Details/5
        public IActionResult Details(int id)
        {
            MotoristaUsuarioViewModel motorista = new MotoristaUsuarioViewModel();
            motorista.Motorista = _gerenciadorMotorista.ObterPorId(id);
            motorista.Usuario = _gerenciadorUsuario.ObterPorId(motorista.Motorista.IdUsuario);
            return View(motorista);
        }

        public IActionResult Delete(int id)
        {
            MotoristaModel motorista = _gerenciadorMotorista.ObterPorId(id);
            ViewBag.NomeUsuario = _gerenciadorUsuario.ObterPorId(motorista.IdUsuario).Nome;
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (_gerenciadorMotorista.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(_gerenciadorMotorista.ObterPorId(id));
        }
    }
}