using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public ActionResult Index()
        {
            var listViewModels = new List<ViagemRotaViewModel>();
            foreach (var viagem in ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterTodos())
            {
                var rota = RotaService.RotaUnityOfWork.GerenciadorRota.ObterPorId(viagem.IdRota);
                var veiculo = VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);

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
        public ActionResult Details(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterPorId(id);
            ViewBag.rota = RotaService.RotaUnityOfWork.GerenciadorRota.ObterPorId(viagem.IdRota);
            ViewBag.placa = VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);
            return View(viagem);
        }

        // GET: ManterViagem/Create
        public ActionResult Create()
        {
            ViewBag.rotas = new SelectList(RotaService.RotaUnityOfWork.GerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            ViewBag.placas = new SelectList(VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterTodos(), "Id", "Placa");
            return View();
        }

        // POST: ManterViagem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViagemModel viagemModel)
        {
            try
            {
                if (ViagemService.ViagemUnityOfWork.GerenciadorViagem.Inserir(viagemModel))
                    return RedirectToAction(nameof(Index));

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ManterViagem/Edit/5
        public ActionResult Edit(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterPorId(id);
            var rotas = RotaService.RotaUnityOfWork.GerenciadorRota.ObterTodos();
            ViewBag.rotas = new SelectList(RotaService.RotaUnityOfWork.GerenciadorRota.ObterDetalhesRota(), "Id", "DetalhesRota");
            ViewBag.placas = new SelectList(VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterTodos(), "Id", "Placa");
            return View(viagem);
        }

        // POST: ManterViagem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViagemModel viagemModel)
        {
            try
            {
                if (ViagemService.ViagemUnityOfWork.GerenciadorViagem.Editar(viagemModel))
                    return RedirectToAction(nameof(Index));

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ManterViagem/Delete/5
        public ActionResult Delete(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.GerenciadorViagem.ObterPorId(id);
            ViewBag.rota = RotaService.RotaUnityOfWork.GerenciadorRota.ObterPorId(viagem.IdRota);
            ViewBag.placa = VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);
            return View(viagem);
        }

        // POST: ManterViagem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ViagemService.ViagemUnityOfWork.GerenciadorViagem.Remover(id))
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