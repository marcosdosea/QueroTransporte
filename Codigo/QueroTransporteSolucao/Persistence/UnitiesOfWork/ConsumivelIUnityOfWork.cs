using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class ConsumivelIUnityOfWork : IConsumivelUnityOfWork
    {
        public IConsumivelVeicularRepository ConsumivelVeicularRepository { get; }
        public ConsumivelIUnityOfWork(IConsumivelVeicularRepository gerenciadorConsumivelVeicular)
        {
            ConsumivelVeicularRepository = gerenciadorConsumivelVeicular;
        }
    }
}
