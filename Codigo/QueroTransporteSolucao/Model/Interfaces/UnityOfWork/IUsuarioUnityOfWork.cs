using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IUsuarioUnityOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
    }
}
