using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class GerenciadorComprarCredito : IGerenciador<CreditoViagemModel>
    {

        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorComprarCredito(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere na base de dados creditos de viagem comprados um usuario
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(CreditoViagemModel objeto)
        {
            if (ObterPorId(objeto.IdUsuario) == null)
            {
                Credito _credito = new Credito();
                Atribuir(_credito, objeto);
                _context.Add(_credito);
                return _context.SaveChanges() == 1 ? true : false;
            }
            else
            {
                return Editar(objeto);
            }
        }

        /// <summary>
        /// Atualiza saldo de creditos de viagem comprados por um usuário
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Editar(CreditoViagemModel objeto)
        {
            CreditoViagemModel cv = ObterPorId(objeto.IdUsuario);
            cv.Saldo += objeto.Saldo;

            Credito _credito = new Credito();
            Atribuir(_credito, cv);
            _context.Update(_credito);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Atribui dados do model para o objeto a ser inserido no banco 
        /// </summary>
        /// <param name="credito"></param>
        /// <param name="objeto"></param>
        private void Atribuir(Credito credito, CreditoViagemModel objeto)
        {
            credito.Id = objeto.Id;
            credito.Saldo = objeto.Saldo;
            credito.IdUsuario = objeto.IdUsuario;
        }

        /// <summary>
        /// Obtem o saldo de um determinado usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CreditoViagemModel ObterPorId(int id)
        => _context.Credito
                .Where(cv => cv.IdUsuario == id)
                .Select(credito => new CreditoViagemModel
                {
                    Id = credito.Id,
                    Saldo = (decimal)credito.Saldo,
                    IdUsuario = credito.IdUsuario
                }).FirstOrDefault();

        public List<CreditoViagemModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
