using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class ViagemUnityOfWork : IViagemUnityOfWork
    {
        public IViagemRepository ViagemRepository { get; }
        public ViagemUnityOfWork(IViagemRepository gerenciadorViagem)
        {
            ViagemRepository = gerenciadorViagem;
        }
    }
}
