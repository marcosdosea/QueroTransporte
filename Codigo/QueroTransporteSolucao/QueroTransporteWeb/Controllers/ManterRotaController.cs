
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterRotaController : Controller
    {
        private readonly GerenciadorRota _gerenciadorRota;

        public ManterRotaController(GerenciadorRota gerenciadorRota)
        {
            _gerenciadorRota = gerenciadorRota;
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
        public IActionResult Create(RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorRota.Inserir(rotaModel))
                    return RedirectToAction(nameof(Index));
            }

            return View(rotaModel);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.RotaList = new SelectList(_gerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            RotaModel Rota = _gerenciadorRota.ObterPorId(id);
            ViewBag.Checked = Rota.IsComposta;
            return View(Rota);

        }

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

        public IActionResult Details(int id)
        {
            RotaModel rotaModel = _gerenciadorRota.ObterPorId(id);

            if (rotaModel.RotaId != null)
                ViewBag.DetalhesRota = _gerenciadorRota.ObterDetalhesRota((int)rotaModel.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(rotaModel);
        }

        public IActionResult Delete(int id)
        {
            RotaModel rotaModel = _gerenciadorRota.ObterPorId(id);

            if (rotaModel.RotaId != null)
                ViewBag.DetalhesRota = _gerenciadorRota.ObterDetalhesRota((int)rotaModel.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(rotaModel);
        }

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