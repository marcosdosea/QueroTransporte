
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.QueroTransporteWeb
{
    [Authorize]
    public class RotaController : Controller
    {
        private readonly IRotaService RotaService;

        public RotaController(IRotaService gerenciadorRota)
        {
            RotaService = gerenciadorRota;
        }

        /// <summary>
        /// Mostra na tela todas as rotas cadastradas na base de dados
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(RotaService.RotaUnityOfWork.RotaRepository.ObterTodos());
        }


        /// <summary>
        /// Mostra tela para criacao de novas rotas
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {

            ViewBag.RotaList = new SelectList(RotaService.RotaUnityOfWork.RotaRepository.ObterDetalhesRota(), "Id", "DetalhesRota");
            return View();
        }

        /// <summary>
        /// Recebe objeto com nova rota a ser inserida na base de dados
        /// </summary>
        /// <param name="rotaModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                if (RotaService.RotaUnityOfWork.RotaRepository.Inserir(rotaModel))
                    return RedirectToAction(nameof(Index));
            }

            return View(rotaModel);
        }

        /// <summary>
        /// Edita uma rota existente na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            ViewBag.RotaList = new SelectList(RotaService.RotaUnityOfWork.RotaRepository.ObterDetalhesRota(), "Id", "DetalhesRota");
            RotaModel Rota = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(id);
            ViewBag.Checked = Rota.IsComposta;
            return View(Rota);

        }

        /// <summary>
        /// Edita uma rota existente na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rotaModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RotaModel rotaModel)
        {
            if (ModelState.IsValid)
            {
                if (RotaService.RotaUnityOfWork.RotaRepository.Editar(rotaModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(rotaModel);
        }

        /// <summary>
        /// Mostra detalhes de uma rota
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            RotaModel rotaModel = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(id);

            if (rotaModel.RotaId != null)
                ViewBag.DetalhesRota = RotaService.RotaUnityOfWork.RotaRepository.ObterDetalhesRota((int)rotaModel.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(rotaModel);
        }

        /// <summary>
        /// Mostra rota a ser excluida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            RotaModel rotaModel = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(id);

            if (rotaModel.RotaId != null)
                ViewBag.DetalhesRota = RotaService.RotaUnityOfWork.RotaRepository.ObterDetalhesRota((int)rotaModel.RotaId).DetalhesRota;
            else
                ViewBag.DetalhesRota = "--";

            return View(rotaModel);
        }

        /// <summary>
        /// Recebe rota a ser excluida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (!RotaService.RotaUnityOfWork.RotaRepository.Remover(id))
            {
                TempData["mensagemErro"] = "Você não pode remover esta rota porque outras rotas dependem dela!.";
                return RedirectToAction(nameof(Delete));
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Grafico()
        {
            DiasDaSemana Dias = ContagemRotas();
            ViewBag.Segunda = Dias.Segunda;
            ViewBag.Terca = Dias.Terca;
            ViewBag.Quarta = Dias.Quarta;
            ViewBag.Quinta = Dias.Quinta;
            ViewBag.Sexta = Dias.Sexta;
            ViewBag.Sabado = Dias.Sabado;
            ViewBag.Domingo = Dias.Domingo;
            return View();
        }

        private DiasDaSemana ContagemRotas()
        {
            DiasDaSemana dias = new DiasDaSemana();
            List<RotaModel> rotas = RotaService.RotaUnityOfWork.RotaRepository.ObterTodos();
            foreach (var rota in rotas)
            {
                if (rota.DiaSemana.ToLower() == "Segunda".ToLower() ||
                    rota.DiaSemana.ToLower() == "Segunda-feira".ToLower())
                    dias.Segunda++;
                else if (rota.DiaSemana.ToLower() == "Terça".ToLower() ||
                  rota.DiaSemana.ToLower() == "Terça-feira".ToLower())
                    dias.Terca++;
                else if (rota.DiaSemana.ToLower() == "Quarta".ToLower() ||
                   rota.DiaSemana.ToLower() == "Quarta-feira".ToLower())
                    dias.Quarta++;
                else if (rota.DiaSemana.ToLower() == "Quinta".ToLower() ||
                   rota.DiaSemana.ToLower() == "Quinta-feira".ToLower())
                    dias.Quinta++;
                else if (rota.DiaSemana.ToLower() == "Sexta".ToLower() ||
                   rota.DiaSemana.ToLower() == "Sexta-feira".ToLower())
                    dias.Sexta++;
                else if (rota.DiaSemana.ToLower() == "Sabado".ToLower())
                    dias.Sabado++;
                else if (rota.DiaSemana.ToLower() == "Domingo".ToLower())
                    dias.Domingo++;
            }

            return dias;
        }
    }
}