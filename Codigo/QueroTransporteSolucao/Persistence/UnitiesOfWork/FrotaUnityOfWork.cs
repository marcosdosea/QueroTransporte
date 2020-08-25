using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class FrotaUnityOfWork : IFrotaUnityOfWork
    {
        public IFrotaRepository GerenciadorFrota { get; }
        public FrotaUnityOfWork(IFrotaRepository gerenciadorFrota)
        {
            GerenciadorFrota = gerenciadorFrota;
        }
    }
}
