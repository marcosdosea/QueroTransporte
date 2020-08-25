using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class ViagemUnityOfWork : IViagemUnityOfWork
    {
        public IViagemRepository GerenciadorViagem { get; }
        public ViagemUnityOfWork(IViagemRepository gerenciadorViagem)
        {
            GerenciadorViagem = gerenciadorViagem;
        }
    }
}
