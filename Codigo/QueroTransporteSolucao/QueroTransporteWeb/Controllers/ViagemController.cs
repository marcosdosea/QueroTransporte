using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class ViagemController : Controller
    {
        private readonly IViagemService ViagemService;
        private readonly IRotaService RotaService;
        private readonly IVeiculoService VeiculoService;
        public ViagemController(IViagemService gerenciador, IRotaService gerenciadorRota, IVeiculoService gerenciadorVeiculo)
        {
            ViagemService = gerenciador;
            RotaService = gerenciadorRota;
            VeiculoService = gerenciadorVeiculo;
        }
        // GET: ManterViagem
        public IActionResult Index()
        {
            var listViewModels = new List<ViagemRotaViewModel>();
            foreach (var viagem in ViagemService.ViagemUnityOfWork.ViagemRepository.ObterTodos())
            {
                var rota = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(viagem.IdRota);
                var veiculo = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(viagem.IdVeiculo);

                listViewModels.Add(new ViagemRotaViewModel()
                {
                    Rota = rota,
                    Veiculo = veiculo,
                    Viagem = viagem
                });
            }

            return View(listViewModels);
        }

        // GET: ManterViagem/Details/5
        public IActionResult Details(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterPorId(id);
            ViewBag.rota = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(viagem.IdRota);
            ViewBag.placa = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(viagem.IdVeiculo);
            return View(viagem);
        }

        // GET: ManterViagem/Create
        public IActionResult Create()
        {
            ViewBag.rotas = new SelectList(RotaService.RotaUnityOfWork.RotaRepository.ObterDetalhesRota(), "Id", "DetalhesRota");
            ViewBag.placas = new SelectList(VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterTodos(), "Id", "Placa");
            return View();
        }

        // POST: ManterViagem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViagemModel viagemModel)
        {
            try
            {
                if (ViagemService.ViagemUnityOfWork.ViagemRepository.Inserir(viagemModel))
                    return RedirectToAction(nameof(Index));

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ManterViagem/Edit/5
        public IActionResult Edit(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterPorId(id);
            var rotas = RotaService.RotaUnityOfWork.RotaRepository.ObterTodos();
            ViewBag.rotas = new SelectList(RotaService.RotaUnityOfWork.RotaRepository.ObterDetalhesRota(), "Id", "DetalhesRota");
            ViewBag.placas = new SelectList(VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterTodos(), "Id", "Placa");
            return View(viagem);
        }

        // POST: ManterViagem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ViagemModel viagemModel)
        {
            try
            {
                if (ViagemService.ViagemUnityOfWork.ViagemRepository.Editar(viagemModel))
                    return RedirectToAction(nameof(Index));

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ManterViagem/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterPorId(id);
            ViewBag.rota = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(viagem.IdRota);
            ViewBag.placa = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(viagem.IdVeiculo);
            return View(viagem);
        }

        // POST: ManterViagem/Delete/5
        public IActionResult Remove(int id)
        {
            try
            {
                if (ViagemService.ViagemUnityOfWork.ViagemRepository.Remover(id))
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Delete));
            }
            catch
            {
                return RedirectToAction(nameof(Delete));
            }
        }
    }
}