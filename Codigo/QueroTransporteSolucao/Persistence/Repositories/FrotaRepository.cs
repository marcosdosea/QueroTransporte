using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class FrotaRepository : IFrotaRepository
    {
        private readonly ContextDB _context;
        private readonly IMapper _mapper;

        public FrotaRepository(ContextDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FrotaRepository()
        {
        }

        /// <summary>
        /// retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        public virtual List<FrotaModel> ObterTodos()
            => _context.Frota
                .Select(frota => new FrotaModel
                {
                    Id = frota.Id,
                    Titulo = frota.Titulo,
                    Descricao = frota.Descricao,
                    IsPublic = Convert.ToBoolean(frota.EhPublica)
                }).ToList();

        public bool Editar(FrotaModel objeto)
        {
            _context.Frota.Update(_mapper.Map<Frota>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Obtem uma frota especifica da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FrotaModel ObterPorId(int id)
            => _context.Frota
                .Where(frota => frota.Id == id)
                .Select(frota => new FrotaModel
                {
                    Id = frota.Id,
                    Titulo = frota.Titulo,
                    Descricao = frota.Descricao,
                    IsPublic = Convert.ToBoolean(frota.EhPublica)
                }).FirstOrDefault();

        public bool Remover(int id)
        {
            _context.Frota.Remove(_context.Frota.FirstOrDefault(f => f.Id == id));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Insere uma frota na base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(FrotaModel objeto)
        {
            _context.Frota.Add(_mapper.Map<Frota>(objeto));
            return _context.SaveChanges() == 1;
        }
    }
}