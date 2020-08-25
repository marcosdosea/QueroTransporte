using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class PagamentoService : IPagamentoService
    {
        public IPagamentoUnityOfWork PagamentoUnityOfWork { get; }
        public PagamentoService(IPagamentoUnityOfWork pagamentoUnityOfWork)
        {
            PagamentoUnityOfWork = pagamentoUnityOfWork;
        }
    }
}
