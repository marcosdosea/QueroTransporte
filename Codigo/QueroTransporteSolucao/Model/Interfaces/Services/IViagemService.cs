using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IViagemService
    {
        IViagemUnityOfWork ViagemUnityOfWork { get; }
    }
}
