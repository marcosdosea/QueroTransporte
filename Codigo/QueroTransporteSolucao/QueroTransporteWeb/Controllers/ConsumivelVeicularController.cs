using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize]
    public class ConsumivelVeicularController : Controller
    {
        private readonly GerenciadorConsumivelVeicular _gerenciadorConsumivelVeicular;
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;

        public ConsumivelVeicularController(GerenciadorConsumivelVeicular gerenciadorConsumivelVeicular, GerenciadorVeiculo gerenciadorVeiculo)
        {
            _gerenciadorConsumivelVeicular = gerenciadorConsumivelVeicular;
            _gerenciadorVeiculo = gerenciadorVeiculo;
        }

        public IActionResult Index()
        {
            ViewBag.Consumiveis = _gerenciadorConsumivelVeicular.ObterTodos();
            return View(_gerenciadorConsumivelVeicular.ObterTodos());
        }

        public IActionResult Create()
        {
            ViewBag.Consumiveis = new SelectList(_gerenciadorConsumivelVeicular.ObterTodos(), "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConsumivelVeicularModel consumivelveicularModel)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorVeiculo.ObterPorId(consumivelveicularModel.IdVeiculo) != null)
                {
                    if (_gerenciadorConsumivelVeicular.Inserir(consumivelveicularModel))
                        return RedirectToAction(nameof(Index));
                }
            }
            return View(consumivelveicularModel);
        }

        public IActionResult Edit(int id)
        {

            ConsumivelVeicularModel consumivel = _gerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ConsumivelVeicularModel consumivelveicularModel)
        {
            if (ModelState.IsValid)
            {
                if (_gerenciadorConsumivelVeicular.Editar(consumivelveicularModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(consumivelveicularModel);
        }

        public IActionResult Details(int id)
        {
            ConsumivelVeicularModel consumivelveicularModel = _gerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivelveicularModel);
        }

        public IActionResult Delete(int id)
        {
            ConsumivelVeicularModel consumivel = _gerenciadorConsumivelVeicular.ObterPorId(id);
            return View(consumivel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (_gerenciadorConsumivelVeicular.Remover(id))
                return RedirectToAction(nameof(Index));

            return View(_gerenciadorConsumivelVeicular.ObterPorId(id));
        }

        public IActionResult Reports()
        {
            IEnumerable<ConsumivelVeicularModel> cns = _gerenciadorConsumivelVeicular.ObterTodos();
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