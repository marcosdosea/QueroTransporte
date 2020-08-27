using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;

        public RotaRepository(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
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
                    DiaSemana = Enum.GetName(typeof(DayOfWeek), rota.DiaSemana),
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
            _rota.DiaSemana = rotaModel.DiaSemana.Length;
            if (rotaModel.RotaId == -1)
                _rota.IdRota = null;
            else
                _rota.IdRota = rotaModel.RotaId;
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
                      DiaSemana = Enum.GetName(typeof(DayOfWeek), rota.DiaSemana),
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
                    DiaSemana = Enum.GetName(typeof(DayOfWeek), rota.DiaSemana),
                    RotaId = (int)rota.IdRota,
                    IsComposta = Convert.ToBoolean(rota.EhComposta)
                }).ToList();


        /// <summary>
        /// Agrupa dados importantes para identificar cada uma das rotas
        /// </summary>
        /// <returns></returns>
        public List<RotaModel> ObterDetalhesRota()
        {
            List<RotaModel> rotas = ObterTodos();

            rotas.Insert(0, new RotaModel { Id = -1, DetalhesRota = "Não possui" });

            for (int i = 1; i < rotas.Count; i++)
            {
                rotas[i].DetalhesRota = rotas[i].Origem + " - " + rotas[i].Destino +
                    " | " + rotas[i].HorarioSaida + " - " + rotas[i].HorarioChegada + " | " + rotas[i].DiaSemana;
            }

            return rotas;
        }

        /// <summary>
        /// Agrupa dados importantes de uma rota especifica
        /// </summary>
        /// <returns></returns>
        public RotaModel ObterDetalhesRota(int id)
        {
            List<RotaModel> rotas = ObterTodos();
            int index = 0;

            rotas.Insert(0, new RotaModel { Id = -1, DetalhesRota = "Não possui" });

            for (int i = 1; i < rotas.Count; i++)
            {
                if (id == rotas[i].Id)
                {
                    rotas[i].DetalhesRota = rotas[i].Id + " | " + rotas[i].Origem + " - " + rotas[i].Destino;
                    index = i;
                }
            }

            return rotas[index];
        }


        /// <summary>
        /// Pesquisa uma rota por origem e destino
        /// </summary>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public RotaModel ObterPorOrigemDestino(string origem, string destino)
            => _context.Rota
                .Where(r => r.Origem == origem && r.Destino == destino)
                .Select(r => new RotaModel
                {
                    Id = r.Id,
                    Origem = r.Origem,
                    Destino = r.Destino,
                    DiaSemana = Enum.GetName(typeof(DayOfWeek), r.DiaSemana),
                }).FirstOrDefault();

        /// <summary>
        /// Pesquisa uma rota por oriegm, destino e dia da semana
        /// </summary>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <param name="diaSemana"></param>
        /// <returns></returns>
        public List<RotaModel> ObterPorOrigemDestino(string origem, string destino, string diaSemana)
            => _context.Rota
                .Where(r => r.Origem == origem && r.Destino == destino && r.DiaSemana.Equals(diaSemana))
                .Select(r => new RotaModel
                {
                    Id = r.Id,
                    Origem = r.Origem,
                    Destino = r.Destino,
                    HorarioSaida = r.HorarioSaida,
                    HorarioChegada = r.HorarioChegada,
                    DiaSemana = Enum.GetName(typeof(DayOfWeek), r.DiaSemana),
                    IsComposta = Convert.ToBoolean(r.EhComposta)
                }).ToList();


        /// <summary>
        /// Obtem a quantidade de rotas simples atreladas a uma composta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    DiaSemana = Enum.GetName(typeof(DayOfWeek), rota.DiaSemana),
                    RotaId = (int)rota.IdRota,
                    IsComposta = Convert.ToBoolean(rota.EhComposta)
                }).ToList().Count();
    }
}