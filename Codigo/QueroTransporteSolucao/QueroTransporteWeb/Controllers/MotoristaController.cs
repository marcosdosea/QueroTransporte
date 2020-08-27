
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
        public MotoristaController(IMotoristaService gerenciadorMotorista)
        {
            MotoristaService = gerenciadorMotorista;
        }

        public IActionResult Index()
        {
            var listViewModel = new List<MotoristaUsuarioViewModel>();
            foreach (var motorista in MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.ObterTodos())
            {
                var usuario = MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.ObterPorId(motorista.IdUsuario);

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
            ViewBag.UsuariosMotoristas = new SelectList(MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.ObterUsuariosMotoristas(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                MotoristaService.MotoristaUsuarioUnityOfWork.BeginTransaction();
                if (MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.Inserir(motorista))
                {
                    var usuario = MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.ObterPorId(motorista.IdUsuario);
                    usuario.Tipo = "MOTORISTA";
                    if (MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.Editar(usuario))
                    {
                        MotoristaService.MotoristaUsuarioUnityOfWork.Commit();
                        return RedirectToAction(nameof(Index));
                    }
                    else MotoristaService.MotoristaUsuarioUnityOfWork.Rollback();
                }
                else MotoristaService.MotoristaUsuarioUnityOfWork.Rollback();
                // TODO: Retornar uma mensagem ao usuario, caso tente cadastrar um motorista a um usuario já cadastrado.
                // Tipo: Motorista X = Usuario X => Motorista Y = Motorista X ... Isso quebra o banco e retorna o erro p a aplicação.
            }

            ViewBag.UsuariosMotoristas = new SelectList(MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.ObterUsuariosMotoristas(), "Id", "Nome");
            return View(motorista);
        }
        public IActionResult Edit(int id)
        {
            var motorista = MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.ObterPorId(id);
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                if (MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.Editar(motorista))
                    return RedirectToAction(nameof(Index));

            }
            return View(motorista);
        }

        // GET: Usuario/Details/5
        public IActionResult Details(int id)
        {
            var motorista = new MotoristaUsuarioViewModel();
            motorista.Motorista = MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.ObterPorId(id);
            motorista.Usuario = MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.ObterPorId(motorista.Motorista.IdUsuario);
            return View(motorista);
        }

        public IActionResult Delete(int id)
        {
            MotoristaModel motorista = MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.ObterPorId(id);
            ViewBag.NomeUsuario = MotoristaService.MotoristaUsuarioUnityOfWork.UsuarioRepository.ObterPorId(motorista.IdUsuario).Nome;
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(MotoristaService.MotoristaUsuarioUnityOfWork.MotoristaRepository.ObterPorId(id));
        }
    }
}