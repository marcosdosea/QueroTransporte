using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IUsuarioUnityOfWork UsuarioUnityOfWork { get; }
    }
}
