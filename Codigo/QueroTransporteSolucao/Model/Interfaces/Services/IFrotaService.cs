using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IFrotaService
    {
        IFrotaUnityOfWork FrotaUnityOfWork { get; }
    }
}
