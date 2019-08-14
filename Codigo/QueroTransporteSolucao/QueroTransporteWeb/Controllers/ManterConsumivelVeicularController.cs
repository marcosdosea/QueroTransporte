using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using Business;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterConsumivelVeicularController : Controller
    {
        private readonly GerenciadorConsumivelVeicular _gerenciadorConsumivelVeicular;
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;

        public ManterConsumivelVeicularController(GerenciadorConsumivelVeicular gerenciadorConsumivelVeicular, GerenciadorVeiculo gerenciadorVeiculo)
        {
            _gerenciadorConsumivelVeicular = gerenciadorConsumivelVeicular;
            _gerenciadorVeiculo = gerenciadorVeiculo;
        }

        public IActionResult Index()
        {
            ViewBag.Consumiveis = _gerenciadorConsumivelVeicular.ObterTodos();
            return View(_gerenciadorConsumivelVeicular.ObterTodos());
        }

        public IActionResult Create()
        {
            ViewBag.Consumiveis = new SelectList(_gerenciadorConsumivelVeicular.ObterTodos(), "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConsumivelVeicularModel consumivelveicularModel)
        {
            _gerenciadorConsumivelVeicular.Inserir(consumivelveicularModel);
            return View(consumivelveicularModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Consumiveis = new SelectList(_gerenciadorConsumivelVeicular.ObterTodos(), "Id");
            ConsumivelVeicularModel consumivel = _gerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ConsumivelVeicularModel consumivelveicularModel)
        {
            _gerenciadorConsumivelVeicular.Editar(consumivelveicularModel);
            return View(consumivelveicularModel);
        }

        public IActionResult Details(int id)
        {
            ConsumivelVeicularModel consumivelveicularModel = _gerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivelveicularModel);
        }

        public IActionResult Delete(int id)
        {
            ConsumivelVeicularModel consumivel = _gerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (_gerenciadorConsumivelVeicular.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(_gerenciadorConsumivelVeicular.ObterPorId(id));
        }
    }
}