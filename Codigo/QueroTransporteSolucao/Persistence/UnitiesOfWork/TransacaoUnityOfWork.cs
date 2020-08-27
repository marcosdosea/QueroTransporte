using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class TransacaoUnityOfWork : ITransacaoUnityOfWork
    {
        public ITransacaoRepository TransacaoRepository { get; }
        public TransacaoUnityOfWork(ITransacaoRepository gerenciadorTransacao)
        {
            TransacaoRepository = gerenciadorTransacao;
        }
    }
}
