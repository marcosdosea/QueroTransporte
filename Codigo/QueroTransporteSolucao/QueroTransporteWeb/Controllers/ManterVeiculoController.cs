
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterVeiculoController : Controller
    {
        private readonly IGerenciadorVeiculo _gerenciadorVeiculo;
        private readonly IGerenciadorFrota   _gerenciadorFrota;


        public ManterVeiculoController(IGerenciadorVeiculo gerenciadorVeiculo, IGerenciadorFrota gerenciadorFrota)
        {
            _gerenciadorVeiculo = gerenciadorVeiculo;
            _gerenciadorFrota = gerenciadorFrota;
        }


        public IActionResult Index()
        {
            return View(_gerenciadorVeiculo.ObterTodos());
        }

        public IActionResult Create()
        {
            ViewBag.Frotas = new SelectList(_gerenciadorFrota.ObterTodos(), "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoModel veiculo)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorVeiculo.Inserir(veiculo);
                return RedirectToAction(nameof(Index));
            }

            return View(veiculo);
        }


        public IActionResult Edit(int Id)
        {
            ViewBag.Frotas = new SelectList(_gerenciadorFrota.ObterTodos(), "Id", "Titulo");
            VeiculoModel veiculo = _gerenciadorVeiculo.Buscar(Id);
            return View(veiculo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, VeiculoModel veiculo)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorVeiculo.Alterar(veiculo);
                return RedirectToAction(nameof(Index));

            }
            return View(veiculo);
        }

        public IActionResult Details(int Id)
        {
            VeiculoModel veiculo = _gerenciadorVeiculo.Buscar(Id);
            ViewBag.TituloFrota = _gerenciadorFrota.Buscar(veiculo.IdFrota).Titulo;
            return View(veiculo);
        }

        public IActionResult Delete(int Id)
        {
            VeiculoModel veiculo = _gerenciadorVeiculo.Buscar(Id);
            ViewBag.TituloFrota = _gerenciadorFrota.Buscar(veiculo.IdFrota).Titulo; 
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, IFormCollection collection)
        {
           _gerenciadorVeiculo.Excluir(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}