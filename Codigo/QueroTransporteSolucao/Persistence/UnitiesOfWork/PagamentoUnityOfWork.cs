using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class PagamentoUnityOfWork : IPagamentoUnityOfWork
    {
        public IPagamentoRepository PagamentoRepository { get; }
        public PagamentoUnityOfWork(IPagamentoRepository gerenciadorPagamento)
        {
            PagamentoRepository = gerenciadorPagamento;
        }
    }
}
