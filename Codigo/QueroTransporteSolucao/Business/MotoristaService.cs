using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class MotoristaService : IMotoristaService
    {
        public IMotoristaUnityOfWork MotoristaUnityOfWork { get; }
        public MotoristaService(IMotoristaUnityOfWork motoristaUnityOfWork)
        {
            MotoristaUnityOfWork = motoristaUnityOfWork;
        }
    }
}
