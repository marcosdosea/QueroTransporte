using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IRotaUnityOfWork
    {
        IRotaRepository GerenciadorRota { get; }
    }
}
