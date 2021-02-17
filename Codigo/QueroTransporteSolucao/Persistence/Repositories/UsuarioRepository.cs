using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextDB _context;
        private readonly IMapper _mapper;
        public UsuarioRepository(ContextDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Altera um usuario n banco
        /// </summary>
        /// <param name="objeto">Objeto na qual irá sobreescrever o objeto (usuario) antigo</param>
        public bool Editar(UsuarioModel objeto)
        {
            _context.Usuarios.Update(_mapper.Map<Usuarios>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Busca um usuario no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsuarioModel ObterPorId(int id)
            => _context.Usuarios
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
            _context.Remove(_context.Usuarios.FirstOrDefault(x => x.Id == id));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Insere um usuario n banco de dados
        /// </summary>
        /// <param name="objeto">Objeto que será adicionando no banco</param>
        public bool Inserir(UsuarioModel objeto)
        {
            _context.Usuarios.Add(_mapper.Map<Usuarios>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Obter um usuário por cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public UsuarioModel ObterPorCpf(string cpf)
            => _context.Usuarios
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
            => _context.Usuarios
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
        /// O motivo é de fixar na lista de opcoes dos tipos na view, selectList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTipos() => new string[] { "CLIENTE", "MOTORISTA", "ADMIN", "GESTOR" };

        /// <summary>
        /// Serve para retornar os usuarios que são motoristas, ou seja, o elemento 1 do Inumerable de strings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UsuarioModel> ObterUsuariosMotoristas()
            => _context.Usuarios
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

        /// <summary>
        /// Serve para retornar os usuarios que são motoristas, ou seja, o elemento 1 do Inumerable de strings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UsuarioModel> ObterTodosUsuarios()
            => _context.Usuarios
                .Where(usuarioModel => usuarioModel.Tipo.Equals(GetTipos().ElementAt(0)))
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

        public UsuarioModel ObterPorLoginSenha(string cpf, string senha)
            => _context.Usuarios
                .Where(u => u.Cpf.Equals(cpf) && u.Senha.Equals(senha))
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
    }
}