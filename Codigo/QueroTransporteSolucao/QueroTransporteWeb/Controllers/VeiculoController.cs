
using Domain.Interfaces.Services;
using Domain.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using System.Collections.Generic;

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


        public IActionResult Index()
        {
            var lista = new List<VeiculoFrotaViewModel>();
            var veiculos = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterTodos();

            veiculos.ForEach(v => lista.Add(new VeiculoFrotaViewModel { Frota = FrotaService.FrotaUnityOfWork.FrotaRepository.ObterPorId(v.IdFrota), Veiculo = v }));
            return View(lista);
        }

        public IActionResult Create()
        {
            ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterTodos(), "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                if (VeiculoService.VeiculoUnityOfWork.VeiculoRepository.VerificaInsercaoVeiculo(veiculoModel.Chassi, veiculoModel.Placa) == 0)
                {
                    if (VeiculoService.VeiculoUnityOfWork.VeiculoRepository.Inserir(veiculoModel))
                        return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Já existe um veículo com esse chassi ou placa na base de dados";
                    ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterTodos(), "Id", "Titulo");
                    return View(veiculoModel);
                }
            }

            return View(veiculoModel);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterTodos(), "Id", "Titulo");
            VeiculoModel veiculo = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(id);
            return View(veiculo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VeiculoModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                if (!VeiculoService.VeiculoUnityOfWork.VeiculoRepository.VerificaEdicaoExistente(veiculoModel.Chassi, veiculoModel.Placa, veiculoModel.Id))
                {
                    if (VeiculoService.VeiculoUnityOfWork.VeiculoRepository.Editar(veiculoModel))
                        return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["mensagemErro"] = "Já existe um veículo com esse chassi ou placa na base de dados";
                    ViewBag.Frotas = new SelectList(FrotaService.FrotaUnityOfWork.FrotaRepository.ObterTodos(), "Id", "Titulo");
                    return View(veiculoModel);
                }
            }
            return View(veiculoModel);
        }

        public IActionResult Details(int id)
        {
            VeiculoModel veiculoModel = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(id);
            ViewBag.TituloFrota = FrotaService.FrotaUnityOfWork.FrotaRepository.ObterPorId(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        public IActionResult Delete(int id)
        {
            VeiculoModel veiculoModel = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(id);
            ViewBag.TituloFrota = FrotaService.FrotaUnityOfWork.FrotaRepository.ObterPorId(veiculoModel.IdFrota).Titulo;
            return View(veiculoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (VeiculoService.VeiculoUnityOfWork.VeiculoRepository.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(id));
        }
    }
}