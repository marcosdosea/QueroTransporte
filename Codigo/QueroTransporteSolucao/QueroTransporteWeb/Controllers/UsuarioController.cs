using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporteWeb.Resources.Methods;
using System.Linq;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService UsuarioService;

        public UsuarioController(IUsuarioService gerenciadorUsuario)
        {
            UsuarioService = gerenciadorUsuario;
        }

        /// <summary>
        /// método da view padrão do controlador
        /// </summary>
        /// <returns>Todos os usuarios que não são motoristas para o view que lista eles</returns>
        // GET: Usuario
        public ActionResult Index() => View(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterTodos().Where(u => !u.Tipo.Equals("MOTORISTA")));

        /// <summary>
        /// detalha o dados do usuario
        /// </summary>
        /// <param name="id">serve para buscar um usuario, para posteriormente retorna-lo na view</param>
        /// <returns>retorna na view o usuario</returns>
        // GET: Usuario/Details/5
        public ActionResult Details(int id) => View(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(id));

        /// <summary>
        /// Para assim que a funcao criar um usuario é chamada
        /// </summary>
        /// <returns></returns>
        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Tipos = new SelectList(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.GetTipos(), "string");
            return View();
        }

        /// <summary>
        /// Serve para a partir de um formulario receber os dados e criar um usuario 
        /// </summary>
        /// <param name="usuarioModel">Usuario criado a partir do formulario</param>
        /// <returns></returns>
        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.Cpf = MethodsUtils.RemoverCaracteresEspeciais(usuarioModel.Cpf);
                usuarioModel.Telefone = MethodsUtils.RemoverCaracteresEspeciais(usuarioModel.Telefone);
                if (UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.Inserir(usuarioModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        /// <summary>
        /// Assim que é chamada a funcao para editar um determinado usuario
        /// </summary>
        /// <param name="id">id do usuario selecionado para edicao</param>
        /// <returns></returns>
        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioModel user = new UsuarioModel();
            user = UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(id);
            ViewBag.Tipos = new SelectList(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.GetTipos(), "string");
            return View(user);
        }

        /// <summary>
        /// Edita um usuario a partir do formulario 
        /// </summary>
        /// <param name="usuarioModel">Usuario criado a partir do formulario</param>
        /// <returns></returns>
        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.Editar(usuarioModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        /// <summary>
        /// ASsim que é chamada o botao deletar um usuario
        /// </summary>
        /// <param name="id">id do usuario selecionado para exclusao</param>
        /// <returns></returns>
        // GET: Usuario/Delete/5
        public ActionResult Delete(int id) => View(UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.ObterPorId(id));

        /// <summary>
        /// Serve para excluir um usuario
        /// </summary>
        /// <param name="id">id do usario a ser deletado</param>
        /// <param name="collection">Objeto da interface controller</param>
        /// <returns></returns>
        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            UsuarioService.UsuarioUnityOfWork.GerenciadorUsuario.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}