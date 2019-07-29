using Persistence;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorMotorista : IGerenciadorMotorista
    {

        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorMotorista(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motoristaModel"> </param>
        /// <returns> </returns>
        public int Cadastrar(MotoristaModel motoristaModel)
        {
            Motorista _motorista = new Motorista();

            Atribuir(motoristaModel, _motorista);
            _context.Add(_motorista);
            _context.SaveChanges();
            return _motorista.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motoristaModel"> </param>
        public void Alterar(MotoristaModel motoristaModel)
        {
            Motorista _motorista = new Motorista();

            Atribuir(motoristaModel, _motorista);
            _context.Update(_motorista);
            _context.SaveChanges();
        }

        private void Atribuir(MotoristaModel motoristaModel, Motorista _motorista)
        {
            _motorista.Id = motoristaModel.Id;
            _motorista.Categoria = motoristaModel.Categoria;
            _motorista.Validade = motoristaModel.Validade;
            _motorista.Cnh = motoristaModel.Cnh;
            _motorista.IdUsuario = motoristaModel.IdUsuario;
        }

        public MotoristaModel Buscar(int id)
        {
            IEnumerable<MotoristaModel> motoristas = GetQuery().Where(motoristaModel => motoristaModel.Id.Equals(id));

            return motoristas.ElementAtOrDefault(0);
        }

        public void Remover(int Id)
        {
            Motorista motorista = new Motorista();

            motorista = _context.Motorista.Find(Id);
            _context.Motorista.Remove(entity: motorista);
            _context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="motoristaModel"></param>
        public void AlterarMotirsta(MotoristaModel motoristaModel)
        {
            Motorista _motorista = new Motorista();

            Atribuir(motoristaModel, _motorista);
            _context.Update(_motorista);
            _context.SaveChanges();

        }

        private IQueryable<MotoristaModel> GetQuery()
        {
            IQueryable<Motorista> Motorista = _context.Motorista;
            var query = from motorista in Motorista
                        select new MotoristaModel
                        {
                            Id = motorista.Id,
                            Categoria = motorista.Categoria,
                            Validade = motorista.Validade,
                            Cnh = motorista.Cnh,
                            IdUsuario = (int)motorista.IdUsuario
                        };
            return query;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public IEnumerable <MotoristaModel> ObterTodos()
        {
            return GetQuery();
        }
    }
}