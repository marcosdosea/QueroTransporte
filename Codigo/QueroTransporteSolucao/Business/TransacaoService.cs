using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class TransacaoService : ITransacaoService
    {
        public ITransacaoUnityOfWork TransacaoUnityOfWork { get; }
        public TransacaoService(ITransacaoUnityOfWork transacaoUnityOfWork)
        {
            TransacaoUnityOfWork = transacaoUnityOfWork;
        }
    }
}
