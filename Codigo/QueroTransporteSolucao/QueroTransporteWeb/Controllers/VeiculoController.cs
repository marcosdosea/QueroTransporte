
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize(Roles = "ADMIN")]
    public class VeiculoController : Controller
    {
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;
        private readonly GerenciadorFrota _gerenciadorFrota;


        public VeiculoController(GerenciadorVeiculo gerenciadorVeiculo, GerenciadorFrota gerenciadorFrota)
        {
            _gerenciadorVeiculo = gerenciadorVeiculo;
            _gerenciadorFrota = gerenciadorFrota;
        }


        public IActionResult Index() => View(_gerenciadorVeiculo.ObterTodos());

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
                    if (_gerenciadorVeiculo.Inserir(veiculoModel))
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
            VeiculoModel veiculo = _gerenciadorVeiculo.ObterPorId(id);
            return View(veiculo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                if (!_gerenciadorVeiculo.VerificaEdicaoExistente(veiculoModel.Chassi, veiculoModel.Placa, veiculoModel.Id))
                {
                    if (_gerenciadorVeiculo.Editar(veiculoModel))
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
            VeiculoModel veiculoModel = _gerenciadorVeiculo.ObterPorId(id);
            ViewBag.TituloFrota = _gerenciadorFrota.ObterPorId(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        public IActionResult Delete(int id)
        {
            VeiculoModel veiculoModel = _gerenciadorVeiculo.ObterPorId(id);
            ViewBag.TituloFrota = _gerenciadorFrota.ObterPorId(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (_gerenciadorVeiculo.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(_gerenciadorVeiculo.ObterPorId(id));
        }
    }
}