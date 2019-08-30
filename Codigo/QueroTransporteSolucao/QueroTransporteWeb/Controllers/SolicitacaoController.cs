using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using QueroTransporteWeb.Resources.Methods;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace QueroTransporteWeb.Controllers
{
    [Authorize]
    public class SolicitacaoController : Controller
    {
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;
        private readonly GerenciadorViagem _gerenciadorViagem;
        private readonly GerenciadorSolicitacao _gerenciadorSolicitacao;
        private readonly GerenciadorRota _gerenciadorRota;

        public SolicitacaoController(GerenciadorVeiculo gerenciadorVeiculo, GerenciadorViagem gerenciadorViagem, GerenciadorSolicitacao gerenciadorSolicitacao, GerenciadorRota gerenciadorRota)
        {
            _gerenciadorVeiculo = gerenciadorVeiculo;
            _gerenciadorViagem = gerenciadorViagem;
            _gerenciadorSolicitacao = gerenciadorSolicitacao;
            _gerenciadorRota = gerenciadorRota;
        }
        // GET: Solicitacao
        public ActionResult Index()
        {
            var _usuarioLogado = MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity);
            // Retornando todas as viagens do determinado usuario, obtido pelo id setado na sessão.
            var listViewModels = new List<ViagemRotaViewModel>();

            foreach (var solicitacao in _gerenciadorSolicitacao.ObterSolicitacoesAbertasPorUsuario(_usuarioLogado.Id))
            {
                var viagem = _gerenciadorViagem.ObterPorId(solicitacao.IdViagem);
                listViewModels.Add(new ViagemRotaViewModel
                {
                    Rota = _gerenciadorRota.ObterPorId(viagem.IdRota),
                    Veiculo = _gerenciadorVeiculo.ObterPorId(viagem.IdVeiculo),
                    Viagem = viagem
                });
            }

            var rotas = _gerenciadorRota.ObterTodos();
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

            foreach (var rota in _gerenciadorRota.ObterPorOrigemDestino(origem, destino, diaSemana))
            {
                var viagem = _gerenciadorViagem.BuscarPorRota(rota.Id);

                listaViagemRotaViewModel.Add(new ViagemRotaViewModel
                {
                    Rota = rota,
                    Viagem = viagem,
                    Veiculo = _gerenciadorVeiculo.ObterPorId(viagem.IdVeiculo)
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
                if (_gerenciadorSolicitacao.Inserir(x))
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
            var viagem = _gerenciadorViagem.ObterPorId(id);
            var veiculo = _gerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);
            var rota = _gerenciadorRota.ObterPorId(viagem.IdRota);
            var _usuarioLogado = MethodsUtils.RetornaUserLogado((ClaimsIdentity)User.Identity);

            ViewBag.solicitacao = _gerenciadorSolicitacao.ObterPorViagemUsuario(_usuarioLogado.Id, id);
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
                var solicitacao = _gerenciadorSolicitacao.ObterPorViagemUsuario(_usuarioLogado.Id, id);
                if (_gerenciadorSolicitacao.Remover(solicitacao.Id))
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