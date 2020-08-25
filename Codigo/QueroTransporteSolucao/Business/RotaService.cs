using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class RotaService : IRotaService
    {
        public IRotaUnityOfWork RotaUnityOfWork { get; }
        public RotaService(IRotaUnityOfWork rotaUnityOfWork)
        {
            RotaUnityOfWork = rotaUnityOfWork;
        }
    }
}
