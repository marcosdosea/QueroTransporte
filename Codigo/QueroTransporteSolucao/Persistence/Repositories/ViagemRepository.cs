using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly ContextDB _context;
        private readonly IMapper _mapper;
        public ViagemRepository(ContextDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Edita uma viagem cadastrada na base de dados
        /// </summary>
        /// <param name="viagem"></param>
        /// <returns></returns>
        public bool Editar(ViagemModel viagem)
        {
            _context.Viagem.Update(_mapper.Map<Viagem>(viagem));
            return _context.SaveChanges() == 1;
        }


        /// <summary>
        /// Obtem todas as viagens armazenadas na base de dados
        /// </summary>
        /// <returns></returns>
        public List<ViagemModel> ObterTodos()
            => _context.Viagem
                .Select(v => new ViagemModel
                {
                    Id = v.Id,
                    IdRota = v.IdRota,
                    IdVeiculo = v.IdVeiculo,
                    Preco = v.Preco,
                    Lotacao = v.Lotacao,
                    IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                }).ToList();

        /// <summary>
        /// Obtem todas as viagens armazenadas na base de dados completas ou não
        /// </summary>
        /// <returns></returns>
        public List<ViagemModel> ObterTodosAbertos(bool realizada)
            => _context.Viagem
                .Where(v => v.FoiRealizada == Convert.ToByte(realizada))
                .Select(v => new ViagemModel
                {
                    Id = v.Id,
                    IdRota = v.IdRota,
                    IdVeiculo = v.IdVeiculo,
                    Preco = v.Preco,
                    Lotacao = v.Lotacao,
                    IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                }).ToList();

        /// <summary>
        /// busca uma viagem por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViagemModel ObterPorId(int id)
            => _context.Viagem
                .Where(v => v.Id == id)
                .Select(v => new ViagemModel
                {
                    Id = v.Id,
                    IdRota = v.IdRota,
                    IdVeiculo = v.IdVeiculo,
                    Preco = v.Preco,
                    Lotacao = v.Lotacao,
                    IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                }).FirstOrDefault();

        /// <summary>
        /// Busca uma viagem por veiculo
        /// </summary>
        /// <param name="veiculo"></param>
        /// <returns></returns>
        public List<ViagemModel> BuscarPorVeiculo(VeiculoModel veiculo)
            => _context.Viagem
                .Where(v => v.IdVeiculo == veiculo.Id)
                .Select(v => new ViagemModel
                {
                    Id = v.Id,
                    IdRota = v.IdRota,
                    IdVeiculo = v.IdVeiculo,
                    Preco = v.Preco,
                    Lotacao = v.Lotacao,
                    IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                }).ToList();

        /// <summary>
        /// Obten lista de viagens por rota
        /// </summary>
        /// <param name="rota"></param>
        /// <returns></returns>
        public List<ViagemModel> BuscarPorRota(RotaModel rota)
            => _context.Viagem
                .Where(v => v.IdVeiculo == rota.Id)
                .Select(v => new ViagemModel
                {
                    Id = v.Id,
                    IdRota = v.IdRota,
                    IdVeiculo = v.IdVeiculo,
                    Preco = v.Preco,
                    Lotacao = v.Lotacao,
                    IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                }).ToList();

        /// <summary>
        /// Busca uma viagem por id
        /// </summary>
        /// <param name="idRota"></param>
        /// <returns></returns>
        public ViagemModel BuscarPorRota(int idRota)
            => _context.Viagem
                .Where(v => v.IdRota == idRota)
                .Select(v => new ViagemModel
                {
                    Id = v.Id,
                    IdRota = v.IdRota,
                    IdVeiculo = v.IdVeiculo,
                    Preco = v.Preco,
                    Lotacao = v.Lotacao,
                    IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                }).FirstOrDefault();

        /// <summary>
        /// Remove uma viagem da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remover(int id)
        {
            _context.Remove(_context.Viagem.FirstOrDefault(v => v.Id == id));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Insere uma viagem da base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(ViagemModel objeto)
        {
            _context.Viagem.Add(_mapper.Map<Viagem>(objeto));
            return _context.SaveChanges() == 1;
        }
    }
}