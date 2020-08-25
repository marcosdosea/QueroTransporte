using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface ICreditoService
    {
        ICreditoUnityOfWork CreditoUnityOfWork { get; }
    }
}
