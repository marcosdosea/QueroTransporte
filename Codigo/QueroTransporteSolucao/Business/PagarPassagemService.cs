using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class PagarPassagemService : IPagarPassagemService
    {
        public IPagamentoPassagemUnityOfWork PagamentoPassagemUnityOfWork { get; }
        public PagarPassagemService(IPagamentoPassagemUnityOfWork pagamentoPassagemUnityOfWork)
        {
            PagamentoPassagemUnityOfWork = pagamentoPassagemUnityOfWork;
        }
    }
}
