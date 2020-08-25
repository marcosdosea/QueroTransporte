
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize(Roles = "ADMIN")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService VeiculoService;
        private readonly IFrotaService FrotaService;

        public VeiculoController(IVeiculoService gerenciadorVeiculo, IFrotaService gerenciadorFrota)
        {
            VeiculoService = gerenciadorVeiculo;
            FrotaService = gerenciadorFrota;
        }


        public IActionResult Index() => View(VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterTodos());

        public IActionResult Create()
        {
            ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterTodos(), "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                if (VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.VerificaInsercaoVeiculo(veiculoModel.Chassi, veiculoModel.Placa) == 0)
                {
                    if (VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.Inserir(veiculoModel))
                        return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Já existe um veículo com esse chassi ou placa na base de dados";
                    ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterTodos(), "Id", "Titulo");
                    return View(veiculoModel);
                }
            }

            return View(veiculoModel);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterTodos(), "Id", "Titulo");
            VeiculoModel veiculo = VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(id);
            return View(veiculo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                if (!VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.VerificaEdicaoExistente(veiculoModel.Chassi, veiculoModel.Placa, veiculoModel.Id))
                {
                    if (VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.Editar(veiculoModel))
                        return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Já existe um veículo com esse chassi ou placa na base de dados";
                    ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterTodos(), "Id", "Titulo");
                    return View(veiculoModel);
                }
            }
            return View(veiculoModel);
        }

        public IActionResult Details(int id)
        {
            VeiculoModel veiculoModel = VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(id);
            ViewBag.TituloFrota = FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterPorId(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        public IActionResult Delete(int id)
        {
            VeiculoModel veiculoModel = VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(id);
            ViewBag.TituloFrota = FrotaService.FrotaUnityOfWork.GerenciadorFrota.ObterPorId(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(id));
        }
    }
}