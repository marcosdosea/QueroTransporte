using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporteWeb.Resources.Methods;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class SolicitacaoController : Controller
    {
        private readonly IVeiculoService VeiculoService;
        private readonly IViagemService ViagemService;
        private readonly ISolicitacaoService SolicitacaoService;
        private readonly IRotaService RotaService;

        public SolicitacaoController(IVeiculoService gerenciadorVeiculo, IViagemService gerenciadorViagem, ISolicitacaoService gerenciadorSolicitacao, IRotaService gerenciadorRota)
        {
            VeiculoService = gerenciadorVeiculo;
            ViagemService = gerenciadorViagem;
            SolicitacaoService = gerenciadorSolicitacao;
            RotaService = gerenciadorRota;
        }
        // GET: Solicitacao
        public ActionResult Index()
        {
            var _usuarioLogado = MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity);
            // Retornando todas as viagens do determinado usuario, obtido pelo id setado na sessão.
            var listViewModels = new List<ViagemRotaViewModel>();

            foreach (var solicitacao in SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.ObterSolicitacoesAbertasPorUsuario(_usuarioLogado.Id))
            {
                var viagem = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterPorId(solicitacao.IdViagem);
                listViewModels.Add(new ViagemRotaViewModel
                {
                    Rota = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(viagem.IdRota),
                    Veiculo = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(viagem.IdVeiculo),
                    Viagem = viagem
                });
            }

            var rotas = RotaService.RotaUnityOfWork.RotaRepository.ObterTodos();
            ViewBag.rotaOrigem = new SelectList(rotas, "Origem", "Origem");
            ViewBag.rotaDestino = new SelectList(rotas, "Destino", "Destino");
            return View(listViewModels);
        }

        // GET: Solicitacao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Solicitacao/Create
        public ActionResult PreCreate(string origem, string destino, string diaSemana)
        {
            var listaViagemRotaViewModel = new List<ViagemRotaViewModel>();

            foreach (var rota in RotaService.RotaUnityOfWork.RotaRepository.ObterPorOrigemDestino(origem, destino, diaSemana))
            {
                var viagem = ViagemService.ViagemUnityOfWork.ViagemRepository.BuscarPorRota(rota.Id);

                listaViagemRotaViewModel.Add(new ViagemRotaViewModel
                {
                    Rota = rota,
                    Viagem = viagem,
                    Veiculo = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(viagem.IdVeiculo)
                });
            }

            return View(listaViagemRotaViewModel);
        }

        // GET: Solicitacao/Create/1
        [HttpGet]
        public ActionResult Create(int id)
        {
            try
            {
                var _usuarioLogado = MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity);
                var x = new SolicitacaoVeiculoModel { IdUsuario = _usuarioLogado.Id, IdViagem = id, DataSolicitacao = DateTime.Now, IdPagamento = 1 };
                if (SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.Inserir(x))
                {
                    TempData["msg"] = "success";
                    return RedirectToAction("Index", "Solicitacao");
                }

                return RedirectToAction("Index", "Solicitacao");
            }
            catch
            {
                return RedirectToAction("Index", "Solicitacao");
            }
        }

        // GET: Solicitacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Solicitacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Solicitacao/Delete/5
        public ActionResult Delete(int id)
        {
            var viagem = ViagemService.ViagemUnityOfWork.ViagemRepository.ObterPorId(id);
            var veiculo = VeiculoService.VeiculoUnityOfWork.VeiculoRepository.ObterPorId(viagem.IdVeiculo);
            var rota = RotaService.RotaUnityOfWork.RotaRepository.ObterPorId(viagem.IdRota);
            var _usuarioLogado = MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity);

            ViewBag.solicitacao = SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.ObterPorViagemUsuario(_usuarioLogado.Id, id);
            // Obter a solicitação pelo ID da viagem/ID do usuario em questao.
            //var solicitacao = _gerenciadorSolicitacao.ObterPorViagemUsuario(idUsuario, id);
            return View(new ViagemRotaViewModel { Veiculo = veiculo, Rota = rota, Viagem = viagem });
        }

        // POST: Solicitacao/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var _usuarioLogado = MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity);
                var solicitacao = SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.ObterPorViagemUsuario(_usuarioLogado.Id, id);
                if (SolicitacaoService.SolicitacaoUnityOfWork.SolicitacaoRepository.Remover(solicitacao.Id))
                    return RedirectToAction("Index", "Solicitacao", new { msg = "sucess" });

                return RedirectToAction("Index", "Solicitacao", new { msg = "fail" });
            }
            catch
            {
                return RedirectToAction("Index", "Solicitacao");
            }
        }
    }
}