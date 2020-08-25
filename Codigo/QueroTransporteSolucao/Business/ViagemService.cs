using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class ViagemService : IViagemService
    {
        public IViagemUnityOfWork ViagemUnityOfWork { get; }
        public ViagemService(IViagemUnityOfWork viagemUnityOfWork)
        {
            ViagemUnityOfWork = viagemUnityOfWork;
        }
    }
}
