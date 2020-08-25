using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class PagarPassagemUnityOfWork : IPagamentoPassagemUnityOfWork
    {
        public IPagarPassagemRepository GerenciadorPagarPassagem { get; }
        public PagarPassagemUnityOfWork(IPagarPassagemRepository gerenciadorPagarPassagem)
        {
            GerenciadorPagarPassagem = gerenciadorPagarPassagem;
        }
    }
}
