using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IRotaService
    {
        IRotaUnityOfWork RotaUnityOfWork { get; }
    }
}
