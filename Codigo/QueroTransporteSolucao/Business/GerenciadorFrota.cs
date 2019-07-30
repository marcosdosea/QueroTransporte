
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{ 
    public class GerenciadorFrota : IGerenciadorFrota
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorFrota(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  obtem todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        private IQueryable<FrotaModel> GetQuery()
        {
            IQueryable<Frota> Frota = _context.Frota;
            var query = from frota in Frota
                        select new FrotaModel
                        {
                            Id = frota.Id,
                            Titulo = frota.Titulo,
                            Descricao =  frota.Descricao,
                            IsPublic = frota.EhPublica,
                        };
            return query;
        }


        /// <summary>
        /// retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FrotaModel> ObterTodos()
        {
            return GetQuery();
        }

        public void Alterar(FrotaModel frotaModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtem uma frota especifica da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FrotaModel Buscar(int id)
        {
            IEnumerable<FrotaModel> frotas = GetQuery().Where(frotaModel => frotaModel.Id.Equals(id));
            return frotas.ElementAtOrDefault(0);
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(FrotaModel frotaModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FrotaModel> ObterPorTitulo(string titulo)
        {
            throw new NotImplementedException();
        }  
    }
}