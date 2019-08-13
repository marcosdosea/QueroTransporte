using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Negocio;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business;

namespace QueroTransporte.QueroTransporteWeb
{
    public class ManterConsumivelVeicularController : Controller
    {
        private readonly GerenciadorConsumivelVeicular _gerenciadorConsumivelVeicular;
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;

        public ManterConsumivelVeicularController(GerenciadorConsumivelVeicular gerenciadorConsumivelVeicular, GerenciadorVeiculo gerenciadorVeiculo)
        {
            _gerenciadorConsumivelVeicular = gerenciadorConsumivelVeicular;
            _gerenciadorVeiculo = gerenciadorVeiculo;
        }

        public IActionResult Index()
        {
            /* ViewBag.Veiculos = _gerenciadorVeiculo.ObterTodos(); */
            return View(_gerenciadorConsumivelVeicular.ObterTodos());
        }

        public IActionResult Create(ConsumivelVeicularModel consumivelveicularModel)
        {
            return View(consumivelveicularModel);
        }
    }
}