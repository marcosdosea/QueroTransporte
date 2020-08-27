using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class RotaUnityOfWork : IRotaUnityOfWork
    {
        public IRotaRepository RotaRepository { get; }
        public RotaUnityOfWork(IRotaRepository gerenciadorRota)
        {
            RotaRepository = gerenciadorRota;
        }
    }
}
