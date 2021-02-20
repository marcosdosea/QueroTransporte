using Domain.Interfaces.Services;
using Domain.Models.ViewModel;
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
            var consVeic = new List<ConsumivelVeiculoViewModel>();
            foreach (var c in ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterTodos())
                consVeic.Add(new ConsumivelVeiculoViewModel { ConsumivelVeicular = c, Veiculo = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(c.IdVeiculo) });

            return View(consVeic);
        }

        public IActionResult Create()
        {
            ViewBag.Consumiveis = new SelectList(ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterTodos(), "Id");
            ViewBag.Veiculos = new SelectList(VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterTodos(), "Id", "Placa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConsumivelVeicularModel consumivelveicularModel)
        {
            if (ModelState.IsValid)
            {
                if (VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(consumivelveicularModel.IdVeiculo) != null)
                {
                    if (ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.Inserir(consumivelveicularModel))
                        return RedirectToAction(nameof(Index));
                }
            }
            return View(consumivelveicularModel);
        }

        public IActionResult Edit(int id) => View(ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterPorId(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ConsumivelVeicularModel consumivelveicularModel)
        {
            if (ModelState.IsValid)
            {
                if (ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.Editar(consumivelveicularModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(consumivelveicularModel);
        }

        public IActionResult Details(int id) => View(ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterPorId(id));

        public IActionResult Delete(int id) => View(ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterPorId(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterPorId(id));
        }

        public IActionResult Reports()
        {
            IEnumerable<ConsumivelVeicularModel> cns = ConsumivelService.ConsumivelUnityOfWork.ConsumivelVeicularRepository.ObterTodos();
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