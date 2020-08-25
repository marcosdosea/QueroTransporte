using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IConsumivelUnityOfWork
    {
        IConsumivelVeicularRepository GerenciadorConsumivelVeicular { get; }
    }
}
