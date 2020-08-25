using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class CreditoUnityOfWork : ICreditoUnityOfWork
    {
        public IComprarCreditoRepository GerenciadorComprarCredito { get; }
        public CreditoUnityOfWork(IComprarCreditoRepository gerenciadorComprarCredito)
        {
            GerenciadorComprarCredito = gerenciadorComprarCredito;
        }
    }
}
