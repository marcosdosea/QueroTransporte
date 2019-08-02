
using Business;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorUsuario : IGerenciador<UsuarioModel>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorUsuario(BD_QUERO_TRANSPORTEContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Altera um usuario n banco
        /// </summary>
        /// <param name="objeto">Objeto na qual irá sobreescrever o objeto (usuario) antigo</param>
        public bool Editar(UsuarioModel objeto)
        {
            Usuario usuario = new Usuario();
            Atribuir(objeto, usuario);
            _context.Update(usuario);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Busca um usuario no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsuarioModel ObterPorId(int id)
            => _context.Usuario
                .Where(u => u.Id == id)
                .Select(usuario => new UsuarioModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Cpf = usuario.Cpf,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    Tipo = usuario.Tipo
                }).FirstOrDefault();

        /// <summary>
        /// Exclui um usuario do banco
        /// </summary>
        /// <param name="id">serve para buscar um usuario no banco para excluir</param>
        public bool Remover(int id)
        {
            var usuario = _context.Usuario.Find(id);
            _context.Remove(usuario);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Insere um usuario n banco de dados
        /// </summary>
        /// <param name="objeto">Objeto que será adicionando no banco</param>
        public bool Inserir(UsuarioModel objeto)
        {
            Usuario usuario = new Usuario();
            Atribuir(objeto, usuario);
            _context.Add(usuario);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Obter um usuário por cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public UsuarioModel ObterPorCpf(string cpf)
            => _context.Usuario
                .Where(usuarioModel => usuarioModel.Cpf.Equals(cpf))
                .Select(usuario => new UsuarioModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Cpf = usuario.Cpf,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    Tipo = usuario.Tipo
                }).FirstOrDefault();

        /// <summary>
        /// Obter todos os usaurios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioModel> ObterTodos()
            => _context.Usuario
                .Select(usuario => new UsuarioModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Cpf = usuario.Cpf,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    Tipo = usuario.Tipo
                }).ToList();

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
        /// O motivo é de fixar na lista de opcoes dos tipos na view, selectList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTipos() => new string[] { "Cliente", "Motorista", "ADMIN", "Gestor" };

        /// <summary>
        /// Serve para retornar os usuarios que são motoristas, ou seja, o elemento 1 do Inumerable de strings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UsuarioModel> ObterUsuariosMotoristas()
            => _context.Usuario
                .Where(usuarioModel => usuarioModel.Tipo.Equals(GetTipos().ElementAt(1)))
                .Select(usuario => new UsuarioModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Cpf = usuario.Cpf,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    Tipo = usuario.Tipo
                });
    }
}