
using AutoMapper;
using Domain.Interfaces.Repositories;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Gerenciadoras
{
    public class FrotaRepository : IFrotaRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        private readonly IMapper _mapper;

        public FrotaRepository(BD_QUERO_TRANSPORTEContext context, IMapper mapper)
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insere uma frota na base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(FrotaModel objeto)
        {
            _context.Add(_mapper.Map<Frota>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Faz o cast entre um model e uma entidade
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static Frota ModelToPersistence(FrotaModel model, Frota entity)
        {
            entity.Id = model.Id;
            entity.Descricao = model.Descricao;
            entity.Titulo = model.Titulo;
            entity.EhPublica = Convert.ToByte(model.IsPublic);

            return entity;
        }
    }
}