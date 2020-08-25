using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        bool Editar(UsuarioModel objeto);
        IEnumerable<string> GetTipos();
        bool Inserir(UsuarioModel objeto);
        UsuarioModel ObterPorCpf(string cpf);
        UsuarioModel ObterPorId(int id);
        UsuarioModel ObterPorLoginSenha(string cpf, string senha);
        List<UsuarioModel> ObterTodos();
        IEnumerable<UsuarioModel> ObterTodosUsuarios();
        IEnumerable<UsuarioModel> ObterUsuariosMotoristas();
        bool Remover(int id);
    }
}