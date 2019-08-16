using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class GerenciadorSolicitacao : IGerenciador<SolicitacaoVeiculoModel>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorSolicitacao(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }
        public bool Editar(SolicitacaoVeiculoModel objeto)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(SolicitacaoVeiculoModel objeto)
        {
            _context.Add(ModelToEntity(objeto, new Solicitacao { FoiAtentida = Convert.ToByte(false) }));
            return _context.SaveChanges() == 1 ? true : false;
        }

        public SolicitacaoVeiculoModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            var solicitacao = _context.Solicitacao.Where(s => s.Id == id).FirstOrDefault();
            _context.Remove(solicitacao);
            return _context.SaveChanges() == 1 ? true : false;
        }

        // =================== METODOS DE OBTENÇÃO DE DADOS ===================
        // Metodo utilizado por administradores, para ver todas as solicitações...
        public List<SolicitacaoVeiculoModel> ObterTodos()
            => _context
                .Solicitacao
                .Select(s => new SolicitacaoVeiculoModel
                {
                    Id = s.Id,
                    DataSolicitacao = s.DataSolicitacao,
                    IdViagem = s.IdViagem,
                    IdUsuario = s.IdUsuario,
                    IsAtendida = Convert.ToBoolean(s.FoiAtentida),
                    IdPagamento = s.IdPagamento
                }).ToList();

        public List<SolicitacaoVeiculoModel> ObterSolicitacoesAbertasPorUsuario(int idUsuario)
            => _context
                .Solicitacao
                .Where(s => s.IdUsuario == idUsuario && s.FoiAtentida == 0)
                .Select(s => new SolicitacaoVeiculoModel
                {
                    Id = s.Id,
                    DataSolicitacao = s.DataSolicitacao,
                    IdViagem = s.IdViagem,
                    IdUsuario = s.IdUsuario,
                    IsAtendida = Convert.ToBoolean(s.FoiAtentida),
                    IdPagamento = s.IdPagamento
                }).ToList();

        public SolicitacaoVeiculoModel ObterPorViagemUsuario(int idUsuario, int idViagem, int isAtendida = 0)
            => _context
                .Solicitacao
                .Where(s => s.IdUsuario == idUsuario && s.IdViagem == idViagem && s.FoiAtentida == isAtendida)
                .Select(s => new SolicitacaoVeiculoModel
                {
                    Id = s.Id,
                    DataSolicitacao = s.DataSolicitacao,
                    IdViagem = s.IdViagem,
                    IdUsuario = s.IdUsuario,
                    IsAtendida = Convert.ToBoolean(s.FoiAtentida),
                    IdPagamento = s.IdPagamento
                }).FirstOrDefault();

        // Auxs
        private static Solicitacao ModelToEntity(SolicitacaoVeiculoModel model, Solicitacao entity)
        {
            entity.Id = model.Id;
            entity.IdUsuario = model.IdUsuario;
            entity.IdViagem = model.IdViagem;
            entity.DataSolicitacao = model.DataSolicitacao;
            entity.IdPagamento = model.IdPagamento;
            // A atribuição da propriedade "FoiAtendida" será feita via banco de dados.

            return entity;
        }
    }
}
