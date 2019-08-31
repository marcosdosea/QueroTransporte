using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace QueroTransporteWeb.Controllers
{
    
    public class HistoricoDeTransacoesController : Controller
    {

        private readonly GerenciadorTransacao _gerenciadorTransacao;
        private int TamanhoLista = 0; 

        public HistoricoDeTransacoesController(GerenciadorTransacao gerenciadorTransacao)
        {
            _gerenciadorTransacao = gerenciadorTransacao;
        }

        public IActionResult Index()
        {

            TamanhoLista = TamanhoLista + 2;
            return View(_gerenciadorTransacao.ObterTodos(1).Take(TamanhoLista));
        }

        public IActionResult Details(int id)
        {
            TamanhoLista = TamanhoLista + 2;
            TransacaoModel transacao = _gerenciadorTransacao.ObterPorId(id);
            return View(transacao);
        }
    }
}