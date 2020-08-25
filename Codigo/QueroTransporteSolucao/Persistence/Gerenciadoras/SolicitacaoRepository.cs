using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Gerenciadoras
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public SolicitacaoRepository(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }
        public bool Editar(SolicitacaoVeiculoModel objeto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insere uma nova solicitação de viagem na base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(SolicitacaoVeiculoModel objeto)
        {
            _context.Add(ModelToEntity(objeto, new Solicitacao { FoiAtentida = Convert.ToByte(false) }));
            return _context.SaveChanges() == 1 ? true : false;
        }

        public SolicitacaoVeiculoModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove uma solicitacao de veiculo da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remover(int id)
        {
            var solicitacao = _context.Solicitacao.Where(s => s.Id == id).FirstOrDefault();
            _context.Remove(solicitacao);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Obtem todas as solicitacoes de viagem
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Obtem todas as solicitacoes de viagem atendidas ou não.
        /// </summary>
        /// <returns></returns>
        public List<SolicitacaoVeiculoModel> ObterTodosAtendidas(bool atendida)
            => _context
                .Solicitacao
                .Where(s => s.FoiAtentida == Convert.ToByte(atendida))
                .Select(s => new SolicitacaoVeiculoModel
                {
                    Id = s.Id,
                    DataSolicitacao = s.DataSolicitacao,
                    IdViagem = s.IdViagem,
                    IdUsuario = s.IdUsuario,
                    IsAtendida = Convert.ToBoolean(s.FoiAtentida),
                    IdPagamento = s.IdPagamento
                }).ToList();

        /// <summary>
        /// Obtem todas as solicitacoes pendentes de um usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtem uma solicitacao viagem especifica de um usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idViagem"></param>
        /// <param name="isAtendida"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Faz o cast do model para a entidade
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
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
