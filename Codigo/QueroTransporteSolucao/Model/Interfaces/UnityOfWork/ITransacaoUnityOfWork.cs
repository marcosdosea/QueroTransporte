using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface ITransacaoUnityOfWork
    {
        ITransacaoRepository GerenciadorTransacao { get; }
    }
}
