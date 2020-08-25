using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
        IVeiculoUnityOfWork VeiculoUnityOfWork { get; }
    }
}
