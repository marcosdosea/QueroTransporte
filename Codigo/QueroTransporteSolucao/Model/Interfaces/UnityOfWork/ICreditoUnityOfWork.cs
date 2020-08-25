using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface ICreditoUnityOfWork
    {
        IComprarCreditoRepository GerenciadorComprarCredito { get; }
    }
}
