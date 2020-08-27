using Domain.Interfaces.UnityOfWork.Multiple;

namespace Domain.Interfaces.Services
{
    public interface IMotoristaService
    {
        IMotoristaUsuarioUnityOfWork MotoristaUsuarioUnityOfWork { get; }
    }
}
