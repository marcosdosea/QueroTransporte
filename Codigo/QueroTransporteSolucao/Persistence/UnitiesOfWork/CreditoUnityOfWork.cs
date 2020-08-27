using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class CreditoUnityOfWork : ICreditoUnityOfWork
    {
        public IComprarCreditoRepository ComprarCreditoRepository { get; }
        public CreditoUnityOfWork(IComprarCreditoRepository gerenciadorComprarCredito)
        {
            ComprarCreditoRepository = gerenciadorComprarCredito;
        }
    }
}
