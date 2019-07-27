
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


        public ManterVeiculoController(IGerenciadorVeiculo GerenciadorVeiculo, IGerenciadorFrota GerenciadorFrota)
        {
            _gerenciadorVeiculo = GerenciadorVeiculo;
            _gerenciadorFrota = GerenciadorFrota;
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
        public ActionResult Create(VeiculoModel Veiculo)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorVeiculo.Inserir(Veiculo);
                return RedirectToAction(nameof(Index));
            }

            return View(Veiculo);
        }


        public IActionResult Edit(int Id)
        {
            ViewBag.Frotas = new SelectList(_gerenciadorFrota.ObterTodos(), "Id", "Titulo");
            VeiculoModel veiculo = _gerenciadorVeiculo.Buscar(Id);
            return View(veiculo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, VeiculoModel Veiculo)
        {
            if (ModelState.IsValid)
            {
                _gerenciadorVeiculo.Alterar(Veiculo);
                return RedirectToAction(nameof(Index));

            }
            return View(Veiculo);
        }

        public IActionResult Details(int Id)
        {
            VeiculoModel Contexto = _gerenciadorVeiculo.Buscar(Id);
            ViewBag.TituloFrota = _gerenciadorFrota.Buscar(Contexto.IdFrota).Titulo;
            return View(Contexto);
        }

        public IActionResult Delete(int Id)
        {
            VeiculoModel Contexto = _gerenciadorVeiculo.Buscar(Id);
            ViewBag.TituloFrota = _gerenciadorFrota.Buscar(Contexto.IdFrota).Titulo; 
            return View(Contexto);
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