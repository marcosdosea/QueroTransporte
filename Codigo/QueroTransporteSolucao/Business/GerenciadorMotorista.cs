using Business;
using Persistence;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorMotorista : IGerenciador<MotoristaModel>
    {

        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorMotorista(BD_QUERO_TRANSPORTEContext context)
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
        /// 
        /// </summary>
        /// <param name="motoristaModel"> </param>
        public bool Alterar(MotoristaModel objeto)
        {
            Motorista _motorista = new Motorista();

            Atribuir(objeto, _motorista);
            _context.Update(_motorista);
            return _context.SaveChanges() == 1 ? true : false;
        }

        private void Atribuir(MotoristaModel motoristaModel, Motorista _motorista)
        {
            _motorista.Id = motoristaModel.Id;
            _motorista.Categoria = motoristaModel.Categoria;
            _motorista.Validade = motoristaModel.Validade;
            _motorista.Cnh = motoristaModel.Cnh;
            _motorista.IdUsuario = motoristaModel.IdUsuario;
        }

        public MotoristaModel ObterPorId(int id)
            => _context.Motorista.Where(motorista => motorista.Id == id)
                .Select(motorista => new MotoristaModel
                {
                    Id = motorista.Id,
                    Categoria = motorista.Categoria,
                    Validade = motorista.Validade,
                    Cnh = motorista.Cnh,
                    IdUsuario = (int)motorista.IdUsuario
                }).FirstOrDefault();

        public bool Remover(int id)
        {
            _context.Motorista.Remove(_context.Motorista.Find(id));
            return _context.SaveChanges() == 1 ? true : false;
        }
        /// <summary>
        /// 
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
        ///  
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
                    IdUsuario = (int)motorista.IdUsuario
                }).ToList();
    }
}