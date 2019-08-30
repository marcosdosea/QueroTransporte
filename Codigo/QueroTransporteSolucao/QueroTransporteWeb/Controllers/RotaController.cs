
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize]
    public class RotaController : Controller
    {
        private readonly GerenciadorRota _gerenciadorRota;

        public RotaController(GerenciadorRota gerenciadorRota)
        {
            _gerenciadorRota = gerenciadorRota;
        }

        /// <summary>
        /// Mostra na tela todas as rotas cadastradas na base de dados
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_gerenciadorRota.ObterTodos());
        }


        /// <summary>
        /// Mostra tela para criacao de novas rotas
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            return View();
        }

        /// <summary>
        /// Recebe objeto com nova rota a ser inserida na base de dados
        /// </summary>
        /// <param name="rotaModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorRota.Inserir(rotaModel))
                    return RedirectToAction(nameof(Index));
            }

            return View(rotaModel);
        }

        /// <summary>
        /// Edita uma rota existente na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            RotaModel Rota = _gerenciadorRota.ObterPorId(id);
            ViewBag.Checked = Rota.IsComposta;
            return View(Rota);

        }

        /// <summary>
        /// Edita uma rota existente na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rotaModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorRota.Editar(rotaModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(rotaModel);
        }

        /// <summary>
        /// Mostra detalhes de uma rota
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            RotaModel rotaModel = _gerenciadorRota.ObterPorId(id);

            if (rotaModel.RotaId != null)
                ViewBag.DetalhesRota = _gerenciadorRota.ObterDetalhesRota((int)rotaModel.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(rotaModel);
        }

        /// <summary>
        /// Mostra rota a ser excluida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            RotaModel rotaModel = _gerenciadorRota.ObterPorId(id);

            if (rotaModel.RotaId != null)
                ViewBag.DetalhesRota = _gerenciadorRota.ObterDetalhesRota((int)rotaModel.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(rotaModel);
        }

        /// <summary>
        /// Recebe rota a ser excluida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (!_gerenciadorRota.Remover(id))
            {
                TempData["mensagemErro"] = "Você não pode remover esta rota porque outras rotas dependem dela!.";
                return RedirectToAction(nameof(Delete));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}