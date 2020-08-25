using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IMotoristaUnityOfWork
    {
        IMotoristaRepository GerenciadorMotorista { get; }
    }
}
