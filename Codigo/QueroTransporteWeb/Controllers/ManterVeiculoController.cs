
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterVeiculoController : Controller
    {
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;

        public ManterVeiculoController(GerenciadorVeiculo gerenciadorVeiculo)
        {
            _gerenciadorVeiculo = gerenciadorVeiculo;
        }


        public IActionResult Index()
        {
            return View(_gerenciadorVeiculo.ObterTodos());
        }

        public IActionResult Create()
        {
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
            return View(veiculo);
        }

        public IActionResult Delete(int Id)
        {
            VeiculoModel veiculo = _gerenciadorVeiculo.Buscar(Id);
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