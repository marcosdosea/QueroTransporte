using Model.ViewModel;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class GerenciadorPagarPassagem : IGerenciador<GerenciadorPagarPassagem>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorPagarPassagem(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Obter viagem que o Usuario está em debito
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public SolicitacaoVeiculoModel ObterViagemPorUsuarioData(int idUsuario, DateTime data) =>
            _context.Solicitacao
            .Where(sol => sol.IdUsuario == idUsuario && sol.FoiAtentida == 1 && sol.IdPagamento == 1) // sol.Data idPag = 0
            .Select(sol => new SolicitacaoVeiculoModel
            {
                Id = sol.Id,
                IdUsuario = sol.IdUsuario,
                IdViagem = sol.IdViagem,
                DataSolicitacao = sol.DataSolicitacao,
                IsAtendida = Convert.ToBoolean(sol.FoiAtentida)
            }).FirstOrDefault();
               

        public bool Editar(GerenciadorPagarPassagem objeto)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(GerenciadorPagarPassagem objeto)
        {
            throw new NotImplementedException();
        }

        public GerenciadorPagarPassagem ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<GerenciadorPagarPassagem> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }

    }
}
