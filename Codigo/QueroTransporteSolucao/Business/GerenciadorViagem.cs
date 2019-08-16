
using Business;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorViagem : IGerenciador<ViagemModel>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorViagem(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Edita uma viagem cadastrada na base de dados
        /// </summary>
        /// <param name="viagem"></param>
        /// <returns></returns>
        public bool Editar(ViagemModel viagem)
        {
            _context.Update(Atribuir(new Viagem(), viagem));
            return _context.SaveChanges() == 1 ? true : false;
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
        public List<ViagemModel> BuscarPorRota(Rota rota)
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
            _context.Remove(_context.Viagem.Where(v => v.Id == id).FirstOrDefault());
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Insere uma viagem da base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(ViagemModel objeto)
        {
            _context.Add(Atribuir(new Viagem(), objeto));
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// faz um cast entre um Model e a entidade
        /// </summary>
        /// <param name="viagem"></param>
        /// <param name="_viagem"></param>
        /// <returns></returns>
        private Viagem Atribuir(Viagem viagem, ViagemModel _viagem)
        {
            viagem.Id = _viagem.Id;
            viagem.IdRota = _viagem.IdRota;
            viagem.IdVeiculo = _viagem.IdVeiculo;
            viagem.Preco = _viagem.Preco;
            viagem.Lotacao = _viagem.Lotacao;
            viagem.FoiRealizada = _viagem.IsRealizada ? (byte)1 : (byte)0;

            return viagem;
        }
    }
}