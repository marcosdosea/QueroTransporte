using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class SolicitacaoUnityOfWork : ISolicitacaoUnityOfWork
    {
        public ISolicitacaoRepository SolicitacaoRepository { get; }
        public SolicitacaoUnityOfWork(ISolicitacaoRepository gerenciadorSolicitacao)
        {
            SolicitacaoRepository = gerenciadorSolicitacao;
        }
    }
}
