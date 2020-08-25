using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioUnityOfWork UsuarioUnityOfWork { get; }
        public UsuarioService(IUsuarioUnityOfWork usuarioUnityOfWork)
        {
            UsuarioUnityOfWork = usuarioUnityOfWork;
        }
    }
}
