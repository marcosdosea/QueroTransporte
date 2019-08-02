using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporte.Negocio;

namespace QueroTransporteWeb.Controllers
{
    public class ViagemController : Controller
    {
        private readonly GerenciadorViagem _gerenciador;
        private readonly GerenciadorRota _gerenciadorRota;
        private readonly GerenciadorVeiculo _gerenciadorVeiculo;
        public ViagemController(GerenciadorViagem gerenciador, GerenciadorRota gerenciadorRota, GerenciadorVeiculo gerenciadorVeiculo)
        {
            _gerenciador = gerenciador;
            _gerenciadorRota = gerenciadorRota;
            _gerenciadorVeiculo = gerenciadorVeiculo;
        }
        // GET: ManterViagem
        public ActionResult Index()
        {
            ViewBag.rotas = _gerenciadorRota.ObterTodos();
            ViewBag.placas = _gerenciadorVeiculo.ObterTodos();
            return View(_gerenciador.ObterTodos());
        }

        // GET: ManterViagem/Details/5
        public ActionResult Details(int id)
        {
            var viagem = _gerenciador.ObterPorId(id);
            ViewBag.rota = _gerenciadorRota.ObterPorId(viagem.IdRota);
            ViewBag.placa = _gerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);
            return View(viagem);
        }

        // GET: ManterViagem/Create
        public ActionResult Create()
        {
            var rotas = _gerenciadorRota.ObterTodos();
            ViewBag.rotaOrigem = new SelectList(rotas, "Origem", "Origem");
            ViewBag.rotaDestino = new SelectList(rotas, "Destino", "Destino");
            ViewBag.placas = new SelectList(_gerenciadorVeiculo.ObterTodos(), "Id", "Placa");
            return View();
        }

        // POST: ManterViagem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViagemRotaViewModel viagemViewModel)
        {
            try
            {
                // Retornando para reinserir os dados.
                var rota = _gerenciadorRota.ObterPorOrigemDestino(viagemViewModel.Origem, viagemViewModel.Destino);
                if (rota == null)
                {
                    // TODO: INSERIR NA ENTIDADE DE ROTAS, PORÉM, DEVE PREENCHER OS HORARIOS.
                    return View();
                }

                // 
                var viagem = new ViagemModel
                {
                    IdRota = rota.Id,
                    IdVeiculo = viagemViewModel.IdVeiculo,
                    Preco = viagemViewModel.Preco,
                    Lotacao = viagemViewModel.Lotacao,
                    IsRealizada = viagemViewModel.IsRealizada
                };

                if (_gerenciador.Inserir(viagem))
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
            var viagem = _gerenciador.ObterPorId(id);
            var rotas = _gerenciadorRota.ObterTodos();
            ViewBag.rotaOrigem = new SelectList(rotas, "Origem", "Origem");
            ViewBag.rotaDestino = new SelectList(rotas, "Destino", "Destino");
            ViewBag.placas = new SelectList(_gerenciadorVeiculo.ObterTodos(), "Id", "Placa");
            return View(viagem);
        }

        // POST: ManterViagem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViagemRotaViewModel viagemViewModel)
        {
            try
            {
                var rota = _gerenciadorRota.ObterPorOrigemDestino(viagemViewModel.Origem, viagemViewModel.Destino);
                if (rota == null)
                {
                    // TODO: INSERIR NA ENTIDADE DE ROTAS, PORÉM, DEVE PREENCHER OS HORARIOS.
                    return View();
                }

                //
                var viagem = new ViagemModel
                {
                    IdRota = rota.Id,
                    IdVeiculo = viagemViewModel.IdVeiculo,
                    Preco = viagemViewModel.Preco,
                    Lotacao = viagemViewModel.Lotacao,
                    IsRealizada = viagemViewModel.IsRealizada
                };

                if (_gerenciador.Editar(viagem))
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
            var viagem = _gerenciador.ObterPorId(id);
            ViewBag.rota = _gerenciadorRota.ObterPorId(viagem.IdRota);
            ViewBag.placa = _gerenciadorVeiculo.ObterPorId(viagem.IdVeiculo);
            return View(viagem);
        }

        // POST: ManterViagem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (_gerenciador.Remover(id))
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