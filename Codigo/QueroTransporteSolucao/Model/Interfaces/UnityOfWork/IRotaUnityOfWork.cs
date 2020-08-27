using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IRotaUnityOfWork
    {
        IRotaRepository RotaRepository { get; }
    }
}
