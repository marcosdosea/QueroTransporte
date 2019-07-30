
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorViagem : IGerenciadorViagem
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorViagem(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        public bool Alterar(ViagemModel viagem)
        {
            var _viagem = new Viagem();
            _context.Update(Atribuir(_viagem, viagem));
            return _context.SaveChanges() == 1 ? true : false;
        }

        public List<ViagemModel> Buscar() => _context.Viagem
                        .Select(v => new ViagemModel
                        {
                            Id = v.Id,
                            IdRota = v.Rota,
                            IdVeiculo = v.Veiculo,
                            Preco = v.Preco,
                            Lotacao = v.Lotacao,
                            IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                        }).ToList();

        public ViagemModel BuscarPorId(int id) => _context.Viagem.Where(v => v.Id == id)
                            .Select(v => new ViagemModel
                            {
                                Id = v.Id,
                                IdRota = v.Rota,
                                IdVeiculo = v.Veiculo,
                                Preco = v.Preco,
                                Lotacao = v.Lotacao,
                                IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                            }).FirstOrDefault();

        public List<ViagemModel> BuscarPorVeiculo(VeiculoModel veiculo) => _context.Viagem.Where(v => v.Veiculo == veiculo.Id)
                                    .Select(v => new ViagemModel
                                    {
                                        Id = v.Id,
                                        IdRota = v.Rota,
                                        IdVeiculo = v.Veiculo,
                                        Preco = v.Preco,
                                        Lotacao = v.Lotacao,
                                        IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                                    }).ToList();

        public List<ViagemModel> BuscarPorRota(Rota rota) => _context.Viagem.Where(v => v.Veiculo == rota.Id)
                                    .Select(v => new ViagemModel
                                    {
                                        Id = v.Id,
                                        IdRota = v.Rota,
                                        IdVeiculo = v.Veiculo,
                                        Preco = v.Preco,
                                        Lotacao = v.Lotacao,
                                        IsRealizada = Convert.ToBoolean(v.FoiRealizada)
                                    }).ToList();

        public bool Excluir(int id)
        {
            var viagem = _context.Viagem.Where(v => v.Id == id).FirstOrDefault();
            _context.Remove(viagem);
            if (_context.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool Inserir(ViagemModel viagem)
        {
            var _viagem = new Viagem();
            _context.Add(Atribuir(_viagem, viagem));
            return _context.SaveChanges() == 1 ? true : false;
        }

        // Aux
        private Viagem Atribuir(Viagem viagem, ViagemModel _viagem)
        {
            viagem.Id = _viagem.Id;
            viagem.Rota = _viagem.IdRota;
            viagem.Veiculo = _viagem.IdVeiculo;
            viagem.Preco = _viagem.Preco;
            viagem.Lotacao = _viagem.Lotacao;
            viagem.FoiRealizada = _viagem.IsRealizada ? (byte)1 : (byte)0;

            return viagem;
        }
    }
}