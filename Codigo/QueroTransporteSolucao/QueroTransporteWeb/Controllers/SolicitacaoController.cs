using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporteWeb.Controllers
{
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
        public ActionResult Index(int id)
        {
            // Retornando todas as viagens do determinado usuario, obtido pelo id setado na sessão.
            var listViewModels = new List<ViagemRotaViewModel>();

            foreach (var solicitacao in _gerenciadorSolicitacao.ObterSolicitacoesAbertasPorUsuario(id))
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
                // Utilizar Tokens ao invés de ID diretamente!
                var idUsuario = 1;
                var x = new SolicitacaoVeiculoModel { IdUsuario = idUsuario, IdViagem = id, DataSolicitacao = DateTime.Now, IdPagamento = 1 };
                if (_gerenciadorSolicitacao.Inserir(x))
                    return RedirectToAction("Index", "Solicitacao", new { id = idUsuario });
                else
                    return RedirectToAction("Index", "Solicitacao", null);
            }
            catch
            {
                return RedirectToAction("Index", "Solicitacao", null);
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
            // Utilizar Tokens ao invés de ID diretamente!
            var idUsuario = 1;
            var viagem = _gerenciadorViagem.ObterPorId(id);
            var veiculo = _gerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);
            var rota = _gerenciadorRota.ObterPorId(viagem.IdRota);

            ViewBag.solicitacao = _gerenciadorSolicitacao.ObterPorViagemUsuario(idUsuario, id);
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
                // ID da sessao!
                var idUsuario = 1;
                var solicitacao = _gerenciadorSolicitacao.ObterPorViagemUsuario(idUsuario, id);
                if (_gerenciadorSolicitacao.Remover(solicitacao.Id))
                    return RedirectToAction("Index", "Solicitacao", new { id = idUsuario });
                else
                    return RedirectToAction("Index", "Solicitacao", null);
            }
            catch
            {
                return RedirectToAction("Index", "Solicitacao", null);
            }
        }
    }
}