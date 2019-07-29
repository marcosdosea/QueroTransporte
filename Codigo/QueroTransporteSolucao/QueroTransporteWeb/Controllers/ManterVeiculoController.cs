
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
        public ActionResult Create(VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorVeiculo.VerificaInsercaoVeiculo(veiculoModel.Chassi, veiculoModel.Placa) == 0)
                {
                    _gerenciadorVeiculo.Inserir(veiculoModel);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Já existe um veículo com esse chassi ou placa na base de dados";
                    ViewBag.Frotas = new SelectList(_gerenciadorFrota.ObterTodos(), "Id", "Titulo");
                    return View(veiculoModel);
                }
            }

            return View(veiculoModel);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Frotas = new SelectList(_gerenciadorFrota.ObterTodos(), "Id", "Titulo");
            VeiculoModel veiculo = _gerenciadorVeiculo.Buscar(id);
            return View(veiculo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {

                if (!_gerenciadorVeiculo.VerificaEdicaoExistente(veiculoModel.Chassi, veiculoModel.Placa,veiculoModel.Id))
                {
                    _gerenciadorVeiculo.Alterar(veiculoModel);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Já existe um veículo com esse chassi ou placa na base de dados";
                    ViewBag.Frotas = new SelectList(_gerenciadorFrota.ObterTodos(), "Id", "Titulo");
                    return View(veiculoModel);
                }
                
            }
            return View(veiculoModel);
        }

        public IActionResult Details(int id)
        {
            VeiculoModel veiculoModel = _gerenciadorVeiculo.Buscar(id);
            ViewBag.TituloFrota = _gerenciadorFrota.Buscar(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        public IActionResult Delete(int id)
        {
            VeiculoModel veiculoModel = _gerenciadorVeiculo.Buscar(id);
            ViewBag.TituloFrota = _gerenciadorFrota.Buscar(veiculoModel.IdFrota).Titulo; 
            return View(veiculoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
           _gerenciadorVeiculo.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}