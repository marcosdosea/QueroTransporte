using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class PagarPassagemUnityOfWork : IPagamentoPassagemUnityOfWork
    {
        public IPagarPassagemRepository PagarPassagemRepository { get; }
        public PagarPassagemUnityOfWork(IPagarPassagemRepository gerenciadorPagarPassagem)
        {
            PagarPassagemRepository = gerenciadorPagarPassagem;
        }
    }
}
