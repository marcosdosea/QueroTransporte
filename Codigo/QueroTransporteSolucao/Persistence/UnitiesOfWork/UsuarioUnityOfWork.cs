using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class UsuarioUnityOfWork : IUsuarioUnityOfWork
    {
        public IUsuarioRepository GerenciadorUsuario { get; }
        public UsuarioUnityOfWork(IUsuarioRepository gerenciadorUsuario)
        {
            GerenciadorUsuario = gerenciadorUsuario;
        }
    }
}
