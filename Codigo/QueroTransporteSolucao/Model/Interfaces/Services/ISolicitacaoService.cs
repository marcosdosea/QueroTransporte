using Domain.Interfaces.UnityOfWork;

namespace Domain.Interfaces.Services
{
    public interface ISolicitacaoService
    {
        ISolicitacaoUnityOfWork SolicitacaoUnityOfWork { get; }
    }
}
