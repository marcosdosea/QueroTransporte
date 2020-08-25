using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class FrotaService : IFrotaService
    {
        public IFrotaUnityOfWork FrotaUnityOfWork { get; }
        public FrotaService(IFrotaUnityOfWork frotaUnityOfWork)
        {
            FrotaUnityOfWork = frotaUnityOfWork;
        }
    }
}
