
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorRota : IGerenciadorRota
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
        public int Inserir(RotaModel rotaModel)
        {
            Rota _rota = new Rota();

            _rota.Id = rotaModel.Id;
            _rota.Origem = rotaModel.Origem;
            _rota.Destino = rotaModel.Destino;
            _rota.HorarioChegada = rotaModel.HorarioChegada;
            _rota.HorarioSaida = rotaModel.HorarioSaida;
            _rota.DiaSemana = rotaModel.DiaSemana;

            if (rotaModel.IsComposta)
                _rota.RotaId = rotaModel.RotaId;
            else
                _rota.RotaId = null;

            _rota.EhComposta = rotaModel.IsComposta;

            _context.Add(_rota);
            _context.SaveChanges();
            return _rota.Id;
        }


        /// <summary>
        /// Altera os dados de uma rota da base de dados
        /// </summary>
        /// <param name="rotaModel"></param>
        public void Alterar(RotaModel rotaModel)
        {
            Rota _rota = new Rota();

            Atribuir(rotaModel, _rota);
            _context.Update(_rota);
            _context.SaveChanges();

        }

        /// <summary>
        /// Busca uma rota na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RotaModel Buscar(int id)
        {
            IEnumerable<RotaModel> rotas = GetQuery().Where(rotaModel => rotaModel.Id.Equals(id));

            return rotas.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Exclui uma rota na base de dados
        /// </summary>
        /// <param name="Id"></param>
        public void Excluir(int Id)
        {
            var rota = _context.Rota.Find(Id);
            _context.Rota.Remove(rota);
            _context.SaveChanges();
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
                _rota.RotaId = rotaModel.RotaId;
            else
                _rota.RotaId = null;

            _rota.EhComposta = rotaModel.IsComposta;
        }


        /// <summary>
        /// retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        private IQueryable<RotaModel> GetQuery()
        {
            IQueryable<Rota> Rota = _context.Rota;
            var query = from rota in Rota
                        select new RotaModel
                        {
                            Id = rota.Id,
                            Origem = rota.Origem,
                            Destino = rota.Destino,
                            HorarioChegada = rota.HorarioChegada,
                            HorarioSaida = rota.HorarioSaida,
                            DiaSemana = rota.DiaSemana,
                            RotaId = (int) rota.RotaId,
                            IsComposta = rota.EhComposta
            };
            return query;
        }


        /// <summary>
        /// retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RotaModel> ObterTodos()
        {
            return GetQuery();
        }


        /// <summary>
        /// pesquisa rotas na base de dados com base no destino
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public IEnumerable<RotaModel> ObterPorNome(string destino)
        {
            IEnumerable<RotaModel> rotas = GetQuery().Where(RotaModel => RotaModel.Destino.StartsWith(destino));
            return rotas;
        }

        // estes métodos serão utilizados apenas pela aplicação móvel

        public void Consultar(RotaModel rotaModel)
        {
            throw new NotImplementedException();
        }

        public void ValidarDados(RotaModel rotaModel)
        {
            throw new NotImplementedException();
        }

        public List<RotaModel> ToSelectList() {
            List<RotaModel> rota = ObterTodos().ToList();

            for (int i = 0; i < rota.Count; i++)
            {
                rota[i].RotaComposta = rota[i].Id +" | " + rota[i].Origem +" - " + rota[i].Destino;
            }

            return rota;
        }
    }
}