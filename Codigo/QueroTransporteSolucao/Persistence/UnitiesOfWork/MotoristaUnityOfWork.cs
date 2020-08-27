using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class MotoristaUnityOfWork : IMotoristaUnityOfWork
    {
        public IMotoristaRepository MotoristaRepository { get; }
        public MotoristaUnityOfWork(IMotoristaRepository gerenciadorMotorista)
        {
            MotoristaRepository = gerenciadorMotorista;
        }
    }
}
