using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IConsumivelService
    {
        IConsumivelUnityOfWork ConsumivelUnityOfWork { get; }
    }
}
