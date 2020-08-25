using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class VeiculoService : IVeiculoService
    {
        public IVeiculoUnityOfWork VeiculoUnityOfWork { get; }
        public VeiculoService(IVeiculoUnityOfWork veiculoUnityOfWork)
        {
            VeiculoUnityOfWork = veiculoUnityOfWork;
        }
    }
}
