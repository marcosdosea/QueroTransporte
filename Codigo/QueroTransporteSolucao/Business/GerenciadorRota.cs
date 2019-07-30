
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
using QueroTransporte.Model;

namespace QueroTransporte.Negocio
{
    public class GerenciadorRota : IGerenciadorRota
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorRota(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        public List<RotaModel> Consultar() => _context.Rota
                            .Select(r => new RotaModel
                            {
                                Id = r.Id,
                                Origem = r.Origem,
                                Destino = r.Destino
                            }).ToList();

        public RotaModel ObterPorId(int idRota) => _context.Rota.Where(r => r.Id == idRota)
                                .Select(r => new RotaModel
                                {
                                    Id = r.Id,
                                    Origem = r.Origem,
                                    Destino = r.Destino,
                                    DiaSemana = r.DiaSemana
                                }).FirstOrDefault();

        public RotaModel ObterPorOrigemDestino(string origem, string destino)
            => _context.Rota.Where(r => r.Origem == origem && r.Destino == destino)
                .Select(r => new RotaModel
                {
                    Id = r.Id,
                    Origem = r.Origem,
                    Destino = r.Destino,
                    DiaSemana = r.DiaSemana
                }).FirstOrDefault();

        public void ValidarDados()
        {
            throw new NotImplementedException();
        }
    }
}