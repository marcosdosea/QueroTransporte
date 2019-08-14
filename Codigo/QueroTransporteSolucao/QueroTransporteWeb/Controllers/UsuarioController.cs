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
        private readonly GerenciadorUsuario _gerenciadorUsuario;

        public UsuarioController(GerenciadorUsuario gerenciadorUsuario)
        {
            _gerenciadorUsuario = gerenciadorUsuario;
        }

        /// <summary>
        /// método da view padrão do controlador
        /// </summary>
        /// <returns>Todos os usuarios que não são motoristas para o view que lista eles</returns>
        // GET: Usuario
        public ActionResult Index() => View(_gerenciadorUsuario.ObterTodos().Where(u => u.Tipo != "MOTORISTA"));

        /// <summary>
        /// detalha o dados do usuario
        /// </summary>
        /// <param name="id">serve para buscar um usuario, para posteriormente retorna-lo na view</param>
        /// <returns>retorna na view o usuario</returns>
        // GET: Usuario/Details/5
        public ActionResult Details(int id) => View(_gerenciadorUsuario.ObterPorId(id));

        /// <summary>
        /// Para assim que a funcao criar um usuario é chamada
        /// </summary>
        /// <returns></returns>
        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Tipos = new SelectList(_gerenciadorUsuario.GetTipos(), "string");
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
                if (_gerenciadorUsuario.Inserir(usuarioModel))
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
            user = _gerenciadorUsuario.ObterPorId(id);
            ViewBag.Tipos = new SelectList(_gerenciadorUsuario.GetTipos(), "string");
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
                if (_gerenciadorUsuario.Editar(usuarioModel))
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
        public ActionResult Delete(int id) => View(_gerenciadorUsuario.ObterPorId(id));

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
            _gerenciadorUsuario.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}