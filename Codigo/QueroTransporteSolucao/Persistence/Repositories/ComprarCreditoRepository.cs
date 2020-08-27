using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ComprarCreditoRepository : IComprarCreditoRepository
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        private readonly IMapper _mapper;
        public ComprarCreditoRepository(BD_QUERO_TRANSPORTEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                _context.Credito.Add(_mapper.Map<Credito>(objeto));
                return _context.SaveChanges() == 1;
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
            var cv = ObterPorId(objeto.IdUsuario);
            cv.Saldo += objeto.Saldo;
            _context.Update(_mapper.Map<Credito>(cv));
            return _context.SaveChanges() == 1;
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
            => _context
                .Credito
                .Select(c => new CreditoViagemModel { Id = c.Id, Saldo = (decimal)c.Saldo, IdUsuario = c.IdUsuario })
                .ToList();

        public bool Remover(int id)
        {
            _context.Credito.Remove(_context.Credito.FirstOrDefault(c => c.Id == id));
            return _context.SaveChanges() == 1;
        }
    }
}
