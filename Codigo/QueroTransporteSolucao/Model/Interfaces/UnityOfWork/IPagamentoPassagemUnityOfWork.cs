using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IPagamentoPassagemUnityOfWork
    {
        IPagarPassagemRepository PagarPassagemRepository { get; }
    }
}
