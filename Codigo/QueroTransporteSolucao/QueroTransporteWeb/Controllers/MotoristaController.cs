
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize]
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService MotoristaService;
        private readonly IUsuarioService UsuarioService;
        public MotoristaController(IMotoristaService gerenciadorMotorista, IUsuarioService gerenciadorUsuario)
        {
            MotoristaService = gerenciadorMotorista;
            UsuarioService = gerenciadorUsuario;
        }

        public IActionResult Index()
        {
            var listViewModel = new List<MotoristaUsuarioViewModel>();
            foreach (var motorista in MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.ObterTodos())
            {
                var usuario = UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(motorista.IdUsuario);

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
            ViewBag.UsuariosMotoristas = new SelectList(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterTodosUsuarios(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                if (MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.Inserir(motorista))
                {
                    var usuario = UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(motorista.IdUsuario);
                    usuario.Tipo = "MOTORISTA";
                    UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.Editar(usuario);

                    return RedirectToAction(nameof(Index));
                }

                // TODO: Retornar uma mensagem ao usuario, caso tente cadastrar um motorista a um usuario já cadastrado.
                // Tipo: Motorista X = Usuario X => Motorista Y = Motorista X ... Isso quebra o banco e retorna o erro p a aplicação.
            }

            ViewBag.UsuariosMotoristas = new SelectList(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterUsuariosMotoristas(), "Id", "Nome");
            return View(motorista);
        }
        public IActionResult Edit(int id)
        {
            var motorista = MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.ObterPorId(id);
            return View(new MotoristaUsuarioViewModel { Motorista = motorista, Usuario = UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(motorista.IdUsuario) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                if (MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.Editar(motorista))
                    return RedirectToAction(nameof(Index));

            }
            return View(motorista);
        }

        // GET: Usuario/Details/5
        public IActionResult Details(int id)
        {
            MotoristaUsuarioViewModel motorista = new MotoristaUsuarioViewModel();
            motorista.Motorista = MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.ObterPorId(id);
            motorista.Usuario = UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(motorista.Motorista.IdUsuario);
            return View(motorista);
        }

        public IActionResult Delete(int id)
        {
            MotoristaModel motorista = MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.ObterPorId(id);
            ViewBag.NomeUsuario = UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(motorista.IdUsuario).Nome;
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(MotoristaService.MotoristaUnityOfWork.GerenciadorMotorista.ObterPorId(id));
        }
    }
}