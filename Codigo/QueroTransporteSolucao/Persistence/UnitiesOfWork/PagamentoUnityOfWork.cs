using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class PagamentoUnityOfWork : IPagamentoUnityOfWork
    {
        public IPagamentoRepository GerenciadorPagamento { get; }
        public PagamentoUnityOfWork(IPagamentoRepository gerenciadorPagamento)
        {
            GerenciadorPagamento = gerenciadorPagamento;
        }
    }
}
