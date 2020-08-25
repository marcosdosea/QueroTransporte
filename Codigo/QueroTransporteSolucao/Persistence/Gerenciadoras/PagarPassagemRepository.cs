using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Linq;

namespace Data.Gerenciadoras
{
    public class PagarPassagemRepository : IPagarPassagemRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public PagarPassagemRepository(BD_QUERO_TRANSPORTEContext context)
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

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }

    }
}
