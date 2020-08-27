using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class MotoristaRepository : IMotoristaRepository
    {

        private readonly BD_QUERO_TRANSPORTEContext _context;
        private readonly IMapper _mapper;

        public MotoristaRepository(BD_QUERO_TRANSPORTEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motoristaModel"> </param>
        /// <returns> </returns>
        public bool Inserir(MotoristaModel objeto)
        {
            _context.Motorista.Add(_mapper.Map<Motorista>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Busca motorista da base de dados por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MotoristaModel ObterPorId(int id)
            => _context.Motorista.Where(motorista => motorista.Id == id)
                .Select(motorista => new MotoristaModel
                {
                    Id = motorista.Id,
                    Categoria = motorista.Categoria,
                    Validade = motorista.Validade,
                    Cnh = motorista.Cnh,
                    IdUsuario = motorista.IdUsuario
                }).FirstOrDefault();

        /// <summary>
        /// Remove um motorista da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remover(int id)
        {
            _context.Motorista.Remove(_context.Motorista.Find(id));
            return _context.SaveChanges() == 1;
        }
        /// <summary>
        /// Altera os dados de um motorista da base de dados
        /// </summary>
        /// <param name="objeto"></param>
        public bool Editar(MotoristaModel objeto)
        {
            objeto.IdUsuario = _context.Motorista.Where(x => x.Id == objeto.Id).Select(x => x.IdUsuario).FirstOrDefault();
            _context.Update(_mapper.Map<Motorista>(objeto));
            return _context.SaveChanges() == 1;

        }
        /// <summary>
        ///  Busca todos os motoristas da base de dados
        /// </summary>
        /// <returns></returns>
        public List<MotoristaModel> ObterTodos()
            => _context.Motorista
                .Select(motorista => new MotoristaModel
                {
                    Id = motorista.Id,
                    Categoria = motorista.Categoria,
                    Validade = motorista.Validade,
                    Cnh = motorista.Cnh,
                    IdUsuario = motorista.IdUsuario,
                }).ToList();
    }
}