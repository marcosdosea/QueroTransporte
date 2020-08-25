using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface IPagamentoService
    {
        IPagamentoUnityOfWork PagamentoUnityOfWork { get; }
    }
}
