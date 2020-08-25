using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IPagamentoUnityOfWork
    {
        IPagamentoRepository GerenciadorPagamento { get; }
    }
}
