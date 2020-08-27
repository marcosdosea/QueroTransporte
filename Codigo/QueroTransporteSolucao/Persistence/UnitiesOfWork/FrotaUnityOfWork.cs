using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class FrotaUnityOfWork : IFrotaUnityOfWork
    {
        public IFrotaRepository FrotaRepository { get; }
        public FrotaUnityOfWork(IFrotaRepository gerenciadorFrota)
        {
            FrotaRepository = gerenciadorFrota;
        }
    }
}
