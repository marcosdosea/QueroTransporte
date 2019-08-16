
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

        public bool Editar(ViagemModel viagem)
        {
            _context.Update(Atribuir(new Viagem(), viagem));
            return _context.SaveChanges() == 1 ? true : false;
        }

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

        public bool Remover(int id)
        {
            _context.Remove(_context.Viagem.Where(v => v.Id == id).FirstOrDefault());
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool Inserir(ViagemModel objeto)
        {
            _context.Add(Atribuir(new Viagem(), objeto));
            return _context.SaveChanges() == 1 ? true : false;
        }

        // Aux
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