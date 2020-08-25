using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IMotoristaService
    {
        IMotoristaUnityOfWork MotoristaUnityOfWork { get; }
    }
}
