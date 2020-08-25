using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IViagemUnityOfWork
    {
        IViagemRepository GerenciadorViagem { get; }
    }
}
