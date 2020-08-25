using Domain.Interfaces.Repositories;
using Persistence;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Gerenciadoras
{
    public class ConsumivelRepository : IConsumivelVeicularRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public ConsumivelRepository(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Insere um consumível veicular na base de dados
        /// </summary>
        /// <param name="consumivelveicularModel"></param>
        /// <returns></returns>
        public bool Inserir(ConsumivelVeicularModel objeto)
        {
            ConsumivelVeicular _consumivel = new ConsumivelVeicular();

            Atribuir(objeto, _consumivel);
            _context.Add(_consumivel);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Altera os dados de um veículo na base de dados.
        /// </summary>
        /// <param name="consumivelveicularModel"></param>
        /// <returns></returns>
        public bool Editar(ConsumivelVeicularModel objeto)
        {
            ConsumivelVeicular _consumivel = new ConsumivelVeicular();

            Atribuir(objeto, _consumivel);
            _context.Update(_consumivel);
            return _context.SaveChanges() == 1 ? true : false;
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
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Atribue dados de um objeto para o outro
        /// </summary>
        /// <param name="consumivelveicularModel"></param>
        /// <param name="_consumivel"></param>
        private void Atribuir(ConsumivelVeicularModel consumivelveicularModel, ConsumivelVeicular _consumivel)
        {
            _consumivel.Id = consumivelveicularModel.Id;
            _consumivel.IdVeiculo = consumivelveicularModel.IdVeiculo;
            _consumivel.Valor = consumivelveicularModel.Valor;
            _consumivel.DataDespesa = consumivelveicularModel.DataDespesa;
            _consumivel.Categoria = consumivelveicularModel.Categoria;
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
