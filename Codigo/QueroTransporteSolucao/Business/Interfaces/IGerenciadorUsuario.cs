using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorUsuario
    {
        void Alterar(UsuarioModel usuarioModel);
        UsuarioModel Buscar(int id);
        void Excluir(int id);
        void Inserir(UsuarioModel usuarioModel);
        UsuarioModel ObterPorCpf(string cpf);
        IEnumerable<UsuarioModel> ObterTodos();
        void Autenticar();
        void Validar();
        void ValidarDados();
        IEnumerable<string> GetTipos();
        IEnumerable<UsuarioModel> ObterUsuariosMotoristas();
    }
}