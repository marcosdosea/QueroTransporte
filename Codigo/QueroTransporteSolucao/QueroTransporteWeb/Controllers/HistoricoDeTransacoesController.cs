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

        public HistoricoDeTransacoesController(GerenciadorTransacao gerenciadorTransacao)
        {
            _gerenciadorTransacao = gerenciadorTransacao;
        }

        public IActionResult Index()
        {

            return View(_gerenciadorTransacao.ObterTodos(1));
        }

        public IActionResult Details(int id)
        {
            TransacaoModel transacao = _gerenciadorTransacao.ObterPorId(id);
            return View(transacao);
        }
    }
}
