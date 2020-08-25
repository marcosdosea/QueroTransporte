using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class RotaUnityOfWork : IRotaUnityOfWork
    {
        public IRotaRepository GerenciadorRota { get; }
        public RotaUnityOfWork(IRotaRepository gerenciadorRota)
        {
            GerenciadorRota = gerenciadorRota;
        }
    }
}
