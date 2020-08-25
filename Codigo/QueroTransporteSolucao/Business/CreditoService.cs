using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class CreditoService : ICreditoService
    {
        public ICreditoUnityOfWork CreditoUnityOfWork { get; }
        public CreditoService(ICreditoUnityOfWork creditoUnityOfWork)
        {
            CreditoUnityOfWork = creditoUnityOfWork;
        }
    }
}
