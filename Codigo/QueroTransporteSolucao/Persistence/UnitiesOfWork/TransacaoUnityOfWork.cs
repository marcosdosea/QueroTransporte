using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class TransacaoUnityOfWork : ITransacaoUnityOfWork
    {
        public ITransacaoRepository GerenciadorTransacao { get; }
        public TransacaoUnityOfWork(ITransacaoRepository gerenciadorTransacao)
        {
            GerenciadorTransacao = gerenciadorTransacao;
        }
    }
}
