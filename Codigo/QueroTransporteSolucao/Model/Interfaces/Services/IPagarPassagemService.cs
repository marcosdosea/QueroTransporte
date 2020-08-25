using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IPagarPassagemService
    {
        IPagamentoPassagemUnityOfWork PagamentoPassagemUnityOfWork { get; }
    }
}
