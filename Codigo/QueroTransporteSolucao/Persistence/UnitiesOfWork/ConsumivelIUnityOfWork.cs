using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class ConsumivelIUnityOfWork : IConsumivelUnityOfWork
    {
        public IConsumivelVeicularRepository GerenciadorConsumivelVeicular { get; }
        public ConsumivelIUnityOfWork(IConsumivelVeicularRepository gerenciadorConsumivelVeicular)
        {
            GerenciadorConsumivelVeicular = gerenciadorConsumivelVeicular;
        }
    }
}
