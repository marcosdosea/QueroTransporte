
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
        public int Inserir(RotaModel Rota)
        {
            Rota _rota = new Rota();

            Atribuir(Rota, _rota);

            _context.Add(_rota);
            _context.SaveChanges();
            return _rota.Id;
        }


        /// <summary>
        /// Altera os dados de uma rota da base de dados
        /// </summary>
        /// <param name="rotaModel"></param>
        public void Alterar(RotaModel Rota)
        {
            Rota _rota = new Rota();

            Atribuir(Rota, _rota);
            _context.Update(_rota);
            _context.SaveChanges();

        }

        /// <summary>
        /// Busca uma rota na base de dados
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RotaModel Buscar(int Id)
        {
            IEnumerable<RotaModel> Rotas = GetQuery().Where(rotaModel => rotaModel.Id.Equals(Id));

            return Rotas.ElementAtOrDefault(0);
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
        private void Atribuir(RotaModel Rota, Rota _rota)
        {
            _rota.Id = Rota.Id;
            _rota.Origem = Rota.Origem;
            _rota.Destino = Rota.Destino;
            _rota.HorarioChegada = Rota.HorarioChegada;
            _rota.HorarioSaida = Rota.HorarioSaida;
            _rota.DiaSemana = Rota.DiaSemana;

            if (Rota.IsComposta)
                _rota.RotaId = Rota.RotaId;
            else
                _rota.RotaId = null;

            _rota.EhComposta = Rota.IsComposta;
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
        public IEnumerable<RotaModel> ObterPorNome(string Destino)
        {
            IEnumerable<RotaModel> rotas = GetQuery().Where(RotaModel => RotaModel.Destino.StartsWith(Destino));
            return rotas;
        }


        /// <summary>
        /// Agrupa dados importantes para identificar cada rota
        /// </summary>
        /// <returns></returns>
        public List<RotaModel> ObterDetalhesRota() {
            List<RotaModel> rota = ObterTodos().ToList();

            for (int i = 0; i < rota.Count; i++)
            {
                rota[i].DetalhesRota = rota[i].Id +" | " + rota[i].Origem +" - " + rota[i].Destino;
            }

            return rota;
        }

        /// <summary>
        /// Agrupa dados importantes para identificar uma rota
        /// </summary>
        /// <returns></returns>
        public RotaModel ObterDetalhesRota(int Id)
        {
            List<RotaModel> rota = ObterTodos().ToList();
            int index = 0;

            for (int i = 0; i < rota.Count; i++)
            {
                if (Id == rota[i].Id)
                {
                    rota[i].DetalhesRota = rota[i].Id + " | " + rota[i].Origem + " - " + rota[i].Destino;
                    index = i;    
                }    
            }

            return rota[index];
        }


        // estes métodos serão utilizados apenas pela aplicação móvel

        public void ValidarDados(RotaModel Rota)
        {
            throw new NotImplementedException();
        }
    }
}