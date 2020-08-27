using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class UsuarioUnityOfWork : IUsuarioUnityOfWork
    {
        public IUsuarioRepository UsuarioRepository { get; }
        public UsuarioUnityOfWork(IUsuarioRepository gerenciadorUsuario)
        {
            UsuarioRepository = gerenciadorUsuario;
        }
    }
}
