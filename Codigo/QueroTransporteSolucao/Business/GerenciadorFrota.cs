
using Business;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorFrota : IGerenciador<FrotaModel>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorFrota(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        /// <summary>
        /// retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        public List<FrotaModel> ObterTodos()
            => _context.Frota
                .Select(frota => new FrotaModel
                {
                    Id = frota.Id,
                    Titulo = frota.Titulo,
                    Descricao = frota.Descricao,
                    IsPublic = Convert.ToBoolean(frota.EhPublica)
                }).ToList();

        public bool Editar(FrotaModel objeto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtem uma frota especifica da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FrotaModel ObterPorId(int id)
            => _context.Frota
                .Where(frota => frota.Id == id)
                .Select(frota => new FrotaModel
                {
                    Id = frota.Id,
                    Titulo = frota.Titulo,
                    Descricao = frota.Descricao,
                    IsPublic = Convert.ToBoolean(frota.EhPublica)
                }).FirstOrDefault();

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(FrotaModel objeto)
        {
            throw new NotImplementedException();
        }
    }
}