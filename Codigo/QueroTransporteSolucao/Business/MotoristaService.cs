using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork.Multiple;

namespace Business
{
    public class MotoristaService : IMotoristaService
    {
        public IMotoristaUsuarioUnityOfWork MotoristaUsuarioUnityOfWork { get; }
        public MotoristaService(IMotoristaUsuarioUnityOfWork motoristaUsuarioUnityOfWork)
        {
            MotoristaUsuarioUnityOfWork = motoristaUsuarioUnityOfWork;
        }
    }
}
