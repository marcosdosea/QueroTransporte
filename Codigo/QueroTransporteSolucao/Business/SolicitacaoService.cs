using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class SolicitacaoService : ISolicitacaoService
    {
        public ISolicitacaoUnityOfWork SolicitacaoUnityOfWork { get; }
        public SolicitacaoService(ISolicitacaoUnityOfWork solicitacaoUnityOfWork)
        {
            SolicitacaoUnityOfWork = solicitacaoUnityOfWork;
        }
    }
}
