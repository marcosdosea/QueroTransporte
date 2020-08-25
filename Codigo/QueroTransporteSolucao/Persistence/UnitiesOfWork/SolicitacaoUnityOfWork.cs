using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class SolicitacaoUnityOfWork : ISolicitacaoUnityOfWork
    {
        public ISolicitacaoRepository GerenciadorSolicitacao { get; }
        public SolicitacaoUnityOfWork(ISolicitacaoRepository gerenciadorSolicitacao)
        {
            GerenciadorSolicitacao = gerenciadorSolicitacao;
        }
    }
}
