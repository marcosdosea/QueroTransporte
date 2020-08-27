using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;

        public PagamentoRepository(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }
        public bool Editar(PagamentoPassagemModel objeto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Inserir forma de pagamento
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(PagamentoPassagemModel objeto)
        {
            Pagamento _pagamento = new Pagamento();
            Atribuir(_pagamento, objeto);
            _context.Add(_pagamento);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public PagamentoPassagemModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<PagamentoPassagemModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Atribui dados do model para o objeto a ser inserido no banco 
        /// </summary>
        /// <param name="Pagamento"></param>
        /// <param name="objeto"></param>
        private void Atribuir(Pagamento pagamento, PagamentoPassagemModel objeto)
        {
            int tipoCredito = 2;
            pagamento.Id = objeto.Id;
            pagamento.Data = objeto.Data;
            if (objeto.Tipo == tipoCredito)
                pagamento.Tipo = "CREDITOS";
            else
                pagamento.Tipo = "A VISTA";
        }

    }
}
