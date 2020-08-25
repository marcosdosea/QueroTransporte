using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface ITransacaoService
    {
        ITransacaoUnityOfWork TransacaoUnityOfWork { get; }
    }
}
