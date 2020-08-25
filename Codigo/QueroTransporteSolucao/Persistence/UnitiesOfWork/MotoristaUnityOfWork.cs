using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class MotoristaUnityOfWork : IMotoristaUnityOfWork
    {
        public IMotoristaRepository GerenciadorMotorista { get; }
        public MotoristaUnityOfWork(IMotoristaRepository gerenciadorMotorista)
        {
            GerenciadorMotorista = gerenciadorMotorista;
        }
    }
}
