using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize]
    public class ConsumivelVeicularController : Controller
    {
        private readonly IConsumivelService ConsumivelService;
        private readonly IVeiculoService VeiculoService;

        public ConsumivelVeicularController(IConsumivelService consumivelService, IVeiculoService veiculoService)
        {
            ConsumivelService = consumivelService;
            VeiculoService = veiculoService;
        }

        public IActionResult Index()
        {
            ViewBag.Consumiveis = ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterTodos();
            return View(ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterTodos());
        }

        public IActionResult Create()
        {
            ViewBag.Consumiveis = new SelectList(ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterTodos(), "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConsumivelVeicularModel consumivelveicularModel)
        {
            if (ModelState.IsValid)
            {
                if (VeiculoService.VeiculoUnityOfWork.GerenciadorVeiculo.ObterPorId(consumivelveicularModel.IdVeiculo) != null)
                {
                    if (ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.Inserir(consumivelveicularModel))
                        return RedirectToAction(nameof(Index));
                }
            }
            return View(consumivelveicularModel);
        }

        public IActionResult Edit(int id)
        {

            ConsumivelVeicularModel consumivel = ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ConsumivelVeicularModel consumivelveicularModel)
        {
            if (ModelState.IsValid)
            {
                if (ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.Editar(consumivelveicularModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(consumivelveicularModel);
        }

        public IActionResult Details(int id)
        {
            ConsumivelVeicularModel consumivelveicularModel = ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivelveicularModel);
        }

        public IActionResult Delete(int id)
        {
            ConsumivelVeicularModel consumivel = ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterPorId(id));
        }

        public IActionResult Reports()
        {
            IEnumerable<ConsumivelVeicularModel> cns = ConsumivelService.ConsumivelUnityOfWork.GerenciadorConsumivelVeicular.ObterTodos();
            IEnumerable<RelatorioConsumivelVeicularViewModel> itens = cns.GroupBy(x => x.DataDespesa.Date).Select(y => new RelatorioConsumivelVeicularViewModel
            {
                Data = y.First().DataDespesa.ToString("dd/MM/yyyy"),
                Valor = y.Sum(z => z.Valor),
                ValorMasked = y.Sum(z => z.Valor) + " R$"
            });
            return View(itens);
        }
    }
}