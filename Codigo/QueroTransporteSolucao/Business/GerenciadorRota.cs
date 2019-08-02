using Business;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueroTransporte.Negocio
{
    public class GerenciadorRota : IGerenciador<RotaModel>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorRota(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }


        /// <summary>
        /// Inseri uma rota na base de dados
        /// </summary>
        /// <param name="rotaModel"></param>
        /// <returns></returns>
        public bool Inserir(RotaModel objeto)
        {
            Rota _rota = new Rota();
            Atribuir(objeto, _rota);

            _context.Add(_rota);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Altera os dados de uma rota da base de dados
        /// </summary>
        /// <param name="rotaModel"></param>
        public bool Editar(RotaModel objeto)
        {
            Rota _rota = new Rota();

            Atribuir(objeto, _rota);
            _context.Update(_rota);
            return _context.SaveChanges() == 1 ? true : false;

        }

        /// <summary>
        /// Busca uma rota na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RotaModel ObterPorId(int id)
            => _context.Rota
                .Where(rota => rota.Id == id)
                .Select(rota => new RotaModel
                {
                    Id = rota.Id,
                    Origem = rota.Origem,
                    Destino = rota.Destino,
                    HorarioChegada = rota.HorarioChegada,
                    HorarioSaida = rota.HorarioSaida,
                    DiaSemana = rota.DiaSemana,
                    RotaId = (int)rota.IdRota,
                    IsComposta = Convert.ToBoolean(rota.EhComposta)
                }).FirstOrDefault();

        /// <summary>
        /// Exclui uma rota na base de dados
        /// </summary>
        /// <param name="id"></param>
        public bool Remover(int id)
        {
            var rota = _context.Rota.Find(id);
            if (ObterNumeroDeRotasDependentes(rota.Id) == 0)
            {
                _context.Rota.Remove(rota);
                return _context.SaveChanges() == 1 ? true : false;
            }

            return false;
        }

        /// <summary>
        /// Atribui dados de um model para um objeto de persistencia
        /// </summary>
        /// <param name="rotaModel"></param>
        /// <param name="_rota"></param>
        private void Atribuir(RotaModel rotaModel, Rota _rota)
        {
            _rota.Id = rotaModel.Id;
            _rota.Origem = rotaModel.Origem;
            _rota.Destino = rotaModel.Destino;
            _rota.HorarioChegada = rotaModel.HorarioChegada;
            _rota.HorarioSaida = rotaModel.HorarioSaida;
            _rota.DiaSemana = rotaModel.DiaSemana;

            if (rotaModel.IsComposta)
                _rota.IdRota = rotaModel.RotaId;
            else
                _rota.IdRota = null;

            _rota.EhComposta = Convert.ToByte(rotaModel.IsComposta);
        }

        /// <summary>
        /// retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        public List<RotaModel> ObterTodos()
            => _context.Rota
                  .Select(rota => new RotaModel
                  {
                      Id = rota.Id,
                      Origem = rota.Origem,
                      Destino = rota.Destino,
                      HorarioChegada = rota.HorarioChegada,
                      HorarioSaida = rota.HorarioSaida,
                      DiaSemana = rota.DiaSemana,
                      RotaId = (int)rota.IdRota,
                      IsComposta = Convert.ToBoolean(rota.EhComposta)
                  }).ToList();


        /// <summary>
        /// pesquisa rotas na base de dados com base no destino
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public List<RotaModel> ObterPorNome(string destino)
            => _context.Rota
                .Where(RotaModel => RotaModel.Destino.StartsWith(destino))
                .Select(rota => new RotaModel
                {
                    Id = rota.Id,
                    Origem = rota.Origem,
                    Destino = rota.Destino,
                    HorarioChegada = rota.HorarioChegada,
                    HorarioSaida = rota.HorarioSaida,
                    DiaSemana = rota.DiaSemana,
                    RotaId = (int)rota.IdRota,
                    IsComposta = Convert.ToBoolean(rota.EhComposta)
                }).ToList();


        /// <summary>
        /// Agrupa dados importantes para identificar cada rota
        /// </summary>
        /// <returns></returns>
        public List<RotaModel> ObterDetalhesRota()
        {
            List<RotaModel> rotas = ObterTodos();

            for (int i = 0; i < rotas.Count; i++)
            {
                rotas[i].DetalhesRota = rotas[i].Id + " | " + rotas[i].Origem + " - " + rotas[i].Destino;
            }

            return rotas;
        }

        /// <summary>
        /// Agrupa dados importantes de uma rota 
        /// </summary>
        /// <returns></returns>
        public RotaModel ObterDetalhesRota(int id)
        {
            List<RotaModel> rotas = ObterTodos();
            int index = 0;

            for (int i = 0; i < rotas.Count; i++)
            {
                if (id == rotas[i].Id)
                {
                    rotas[i].DetalhesRota = rotas[i].Id + " | " + rotas[i].Origem + " - " + rotas[i].Destino;
                    index = i;
                }
            }

            return rotas[index];
        }

        public RotaModel ObterPorOrigemDestino(string origem, string destino)
            => _context.Rota.Where(r => r.Origem == origem && r.Destino == destino)
                .Select(r => new RotaModel
                {
                    Id = r.Id,
                    Origem = r.Origem,
                    Destino = r.Destino,
                    DiaSemana = r.DiaSemana
                }).FirstOrDefault();


        // estes métodos serão utilizados apenas pela aplicação móvel
        public int ObterNumeroDeRotasDependentes(int id)
            => _context.Rota
                .Where(rotaModel => rotaModel.IdRota == id)
                .Select(rota => new RotaModel
                {
                    Id = rota.Id,
                    Origem = rota.Origem,
                    Destino = rota.Destino,
                    HorarioChegada = rota.HorarioChegada,
                    HorarioSaida = rota.HorarioSaida,
                    DiaSemana = rota.DiaSemana,
                    RotaId = (int)rota.IdRota,
                    IsComposta = Convert.ToBoolean(rota.EhComposta)
                }).ToList().Count();
    }
}