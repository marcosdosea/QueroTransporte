using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ConsumivelRepository : IConsumivelVeicularRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        private readonly IMapper _mapper;
        public ConsumivelRepository(BD_QUERO_TRANSPORTEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Insere um consumível veicular na base de dados
        /// </summary>
        /// <param name="consumivelveicularModel"></param>
        /// <returns></returns>
        public bool Inserir(ConsumivelVeicularModel objeto)
        {
            _context.ConsumivelVeicular.Add(_mapper.Map<ConsumivelVeicular>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Altera os dados de um veículo na base de dados.
        /// </summary>
        /// <param name="consumivelveicularModel"></param>
        /// <returns></returns>
        public bool Editar(ConsumivelVeicularModel objeto)
        {
            _context.ConsumivelVeicular.Update(_mapper.Map<ConsumivelVeicular>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Remove consumível veicular da base dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remover(int id)
        {
            var consumivel = _context.ConsumivelVeicular.Find(id);
            _context.ConsumivelVeicular.Remove(consumivel);
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Obtém todos os consumíveis veiculares da base de dados
        /// </summary>
        /// <returns></returns>
        public List<ConsumivelVeicularModel> ObterTodos()
             => _context.ConsumivelVeicular
                .Select(consumivel => new ConsumivelVeicularModel
                {
                    Id = consumivel.Id,
                    IdVeiculo = consumivel.IdVeiculo,
                    Valor = consumivel.Valor,
                    DataDespesa = consumivel.DataDespesa,
                    Categoria = consumivel.Categoria
                }).ToList();

        /// <summary>
        /// Pesquisa consumíveis veiculares por id
        /// </summary>
        /// <param name="idConsumivel"></param>
        /// <returns></returns>
        public ConsumivelVeicularModel ObterPorId(int idConsumivel)
        => _context.ConsumivelVeicular.Where(v => v.Id == idConsumivel)
        .Select(v => new ConsumivelVeicularModel
        {
            Id = v.Id,
            IdVeiculo = v.IdVeiculo,
            Valor = v.Valor,
            DataDespesa = v.DataDespesa,
            Categoria = v.Categoria
        }).FirstOrDefault();
    }
}
