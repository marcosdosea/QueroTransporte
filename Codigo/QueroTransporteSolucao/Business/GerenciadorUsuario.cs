
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorUsuario : IGerenciadorUsuario
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorUsuario(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }

        public void Alterar(UsuarioModel usuarioModel)
        {
            Usuario usuario = new Usuario();
            Atribuir(usuarioModel, usuario);
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public UsuarioModel Buscar(int id)
        {
            IQueryable<UsuarioModel> usuario = GetQuery().Where(usuarioModel => usuarioModel.Id.Equals(id));
            return usuario.FirstOrDefault();
        }

        public void Excluir(int id)
        {
            var usuario = _context.Usuario.Find(id);
            _context.Remove(usuario);
            _context.SaveChanges();
        }

        public void Inserir(UsuarioModel usuarioModel)
        {
            Usuario usuario = new Usuario();
            Atribuir(usuarioModel, usuario);
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public
            UsuarioModel ObterPorCpf(string cpf)
        {
            IQueryable<UsuarioModel> usuario = GetQuery().Where(usuarioModel => usuarioModel.Cpf.Equals(cpf));
            return usuario.ElementAtOrDefault(0);
        }

        public IEnumerable<UsuarioModel> ObterTodos()
        {
            return GetQuery();
        }
        public void Autenticar()
        {
            throw new NotImplementedException();
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }

        public void ValidarDados()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obetivo é reaproveitar o código, pois é utilizado em alterar e inserir
        /// </summary>
        /// <param name="usuarioModel">Objeto do modelo</param>
        /// <param name="usuario">Objeto da persistencia</param>
        private void Atribuir(UsuarioModel usuarioModel, Usuario usuario)
        {
            usuario.Id = usuarioModel.Id;
            usuario.Nome = usuarioModel.Nome;
            usuario.Cpf = usuarioModel.Cpf;
            usuario.Email = usuarioModel.Email;
            usuario.Senha = usuarioModel.Senha;
            usuario.Telefone = usuarioModel.Telefone;
            usuario.Tipo = usuarioModel.Tipo;
        }

        /// <summary>
        /// Ajuda nas consultas e deixa módularizado
        /// </summary>
        /// <returns></returns>
        IQueryable<UsuarioModel> GetQuery()
        {
            IQueryable<Usuario> _usuario = _context.Usuario;
            var query = from usuario in _usuario
                        select new UsuarioModel
                        {
                            Id = usuario.Id,
                            Nome = usuario.Nome,
                            Cpf = usuario.Cpf,
                            Email = usuario.Email,
                            Senha = usuario.Senha,
                            Telefone = usuario.Telefone,
                            Tipo = usuario.Tipo
                        };
            return query;
        }

        /// <summary>
        /// O motivo é de fixar na lista de opcoes dos tipos na view, selectList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTipos()
        {
            IEnumerable <string> tipos = new string[] {"Cliente", "Motorista", "ADMIN", "Gestor" };
            return tipos;
        }

    }
}