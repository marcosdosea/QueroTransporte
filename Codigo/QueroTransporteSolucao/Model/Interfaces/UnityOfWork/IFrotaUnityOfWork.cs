using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IFrotaUnityOfWork
    {
        IFrotaRepository FrotaRepository { get; }
    }
}
