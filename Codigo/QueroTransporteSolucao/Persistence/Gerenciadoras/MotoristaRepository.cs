using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Gerenciadoras
{
    public class MotoristaRepository : IMotoristaRepository
    {

        private readonly BD_QUERO_TRANSPORTEContext _context;

        public MotoristaRepository(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motoristaModel"> </param>
        /// <returns> </returns>
        public bool Inserir(MotoristaModel objeto)
        {
            Motorista _motorista = new Motorista();

            Atribuir(objeto, _motorista);
            _context.Add(_motorista);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Faz o cast entre o model e a entidade
        /// </summary>
        /// <param name="motoristaModel"></param>
        /// <param name="_motorista"></param>
        private void Atribuir(MotoristaModel motoristaModel, Motorista _motorista)
        {
            _motorista.Id = motoristaModel.Id;
            _motorista.Categoria = motoristaModel.Categoria;
            _motorista.Validade = motoristaModel.Validade;
            _motorista.Cnh = motoristaModel.Cnh;
            _motorista.IdUsuario = motoristaModel.IdUsuario;
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
            return _context.SaveChanges() == 1 ? true : false;
        }
        /// <summary>
        /// Altera os dados de um motorista da base de dados
        /// </summary>
        /// <param name="objeto"></param>
        public bool Editar(MotoristaModel objeto)
        {
            Motorista _motorista = new Motorista();
            Atribuir(objeto, _motorista);
            _context.Update(_motorista);
            return _context.SaveChanges() == 1 ? true : false;

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