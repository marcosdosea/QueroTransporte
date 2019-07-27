using Persistence;
using QueroTransporte.Model;
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
        public int CadastrarMotorista(MotoristaModel motoristaModel)
        {
            Motorista _motorista = new Motorista();

            _motorista.Id = motoristaModel.Id;
            _motorista.Categoria = motoristaModel.Categoria;
            _motorista.Validade = motoristaModel.Validade;
            _motorista.Cnh = motoristaModel.Cnh;
            _motorista.Usuario = motoristaModel.IdUsuario;

            _context.Add(_motorista);
            _context.SaveChanges();
            return _motorista.Id;
        }

        public void ValidarMotorista()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="motoristaModel"> </param>
        public void AlterarMotorista(MotoristaModel motoristaModel)
        {
            Motorista _motorista = new Motorista();

            Atribuir(motoristaModel, _motorista);
            _context.Update(_motorista);
            _context.SaveChanges();
        }

        private void Atribuir(MotoristaModel motoristaModel, Motorista motorista)
        {
            Motorista _motorista = new Motorista();

            _motorista.Id = motoristaModel.Id;
            _motorista.Categoria = motoristaModel.Categoria;
            _motorista.Validade = motoristaModel.Validade;
            _motorista.Cnh = motoristaModel.Cnh;
            _motorista.Usuario = motoristaModel.IdUsuario;
        }

        public MotoristaModel ConsultarMotorista(int id)
        {
            IEnumerable<MotoristaModel> motoristas = GetQuery().Where(motoristaModel => motoristaModel.Id.Equals(id));

            return motoristas.ElementAtOrDefault(0);
        }

        public void RemoverMotorista(int Id)
        {
            var motorista = _context.Motorista.Find(Id);
            _context.Motorista.Remove(motorista);
            _context.SaveChanges();
        }

        public void ConfirmarCadastro()
        {
            throw new NotImplementedException();
        }

        public void AlterarMotorista()
        {
            throw new NotImplementedException();
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
                            IdUsuario = motorista.IdUsuario
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
        
        public IEnumerable <MotoristaModel> ObterPorNome (string modelo)
        {
            IEnumerable<MotoristaModel> motoristas = GetQuery().Where(MotoristaModel => MotoristaModel.Modelo.StartsWith(modelo));
            return motoristas;
        }

        public void RemoverMotorista()
        {
            throw new NotImplementedException();
        }
    }
}