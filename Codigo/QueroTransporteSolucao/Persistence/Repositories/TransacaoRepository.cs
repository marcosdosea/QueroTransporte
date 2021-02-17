using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {

        private readonly ContextDB _context;
        private readonly IMapper _mapper;
        public TransacaoRepository(ContextDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtem uma determinada transacao de um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TransacaoModel ObterPorId(int id)
        => _context.Transacao
                .Where(tm => tm.Id == id)
                .Select(transacao => new TransacaoModel
                {
                    Id = transacao.Id,
                    IdUsuario = transacao.IdUsuario,
                    QtdCreditos = transacao.QtdCreditos,
                    Valor = transacao.Valor,
                    Deferido = Convert.ToBoolean(transacao.Deferido),
                    Status = transacao.Status,
                    Data = transacao.Data,
                    Tipo = transacao.Tipo
                }).FirstOrDefault();


        /// <summary>
        /// Obtem todas as transacoes de um usuario
        /// </summary>
        /// <returns></returns>
        public List<TransacaoModel> ObterTodos(int idUsuario)
            => _context.Transacao
                .Where(tm => tm.IdUsuario == idUsuario)
                .OrderByDescending(tm => tm.Data)
                .Select(transacao => new TransacaoModel
                {
                    Id = transacao.Id,
                    IdUsuario = transacao.IdUsuario,
                    QtdCreditos = transacao.QtdCreditos,
                    Valor = transacao.Valor,
                    Deferido = Convert.ToBoolean(transacao.Deferido),
                    Status = transacao.Status,
                    Data = transacao.Data,
                    Tipo = transacao.Tipo
                }).ToList();

        /// <summary>
        /// Obtem Todas as transações deferidas/Não deferidas do sistema.
        /// </summary>
        /// <param name="deferido"></param>
        /// <returns></returns>
        public List<TransacaoModel> ObterTodasDeferidas(bool deferido)
            => _context.Transacao
                .Where(tm => tm.Deferido == Convert.ToByte(deferido))
                .Select(transacao => new TransacaoModel
                {
                    Id = transacao.Id,
                    IdUsuario = transacao.IdUsuario,
                    QtdCreditos = transacao.QtdCreditos,
                    Valor = transacao.Valor,
                    Deferido = Convert.ToBoolean(transacao.Deferido),
                    Status = transacao.Status,
                    Data = transacao.Data,
                    Tipo = transacao.Tipo
                }).ToList();

        /// <summary>
        /// Insere uma nova transacao na base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(TransacaoModel objeto)
        {
            _context.Transacao.Add(_mapper.Map<Transacao>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Atualiza os dados de uma transacao da base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Editar(TransacaoModel objeto)
        {
            _context.Transacao.Update(_mapper.Map<Transacao>(objeto));
            return _context.SaveChanges() == 1;
        }

        public bool Remover(int id)
        {
            _context.Transacao.Remove(_context.Transacao.FirstOrDefault(t => t.Id == id));
            return _context.SaveChanges() == 1;
        }

        public List<TransacaoModel> ObterTodos()
            => _context
                .Transacao
                .Select(transacao => new TransacaoModel
                {
                    Id = transacao.Id,
                    IdUsuario = transacao.IdUsuario,
                    QtdCreditos = transacao.QtdCreditos,
                    Valor = transacao.Valor,
                    Deferido = Convert.ToBoolean(transacao.Deferido),
                    Status = transacao.Status,
                    Data = transacao.Data,
                    Tipo = transacao.Tipo
                }).ToList();
    }
}
