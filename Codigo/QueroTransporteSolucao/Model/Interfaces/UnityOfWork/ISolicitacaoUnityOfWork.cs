using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface ISolicitacaoUnityOfWork
    {
        ISolicitacaoRepository GerenciadorSolicitacao { get; }
    }
}
