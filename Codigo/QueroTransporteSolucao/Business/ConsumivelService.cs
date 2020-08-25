using Domain.Interfaces.Services;
using Domain.Interfaces.UnityOfWork;

namespace Business
{
    public class ConsumivelService : IConsumivelService
    {
        public IConsumivelUnityOfWork ConsumivelUnityOfWork { get; }
        public ConsumivelService(IConsumivelUnityOfWork consumivelUnityOfWork)
        {
            ConsumivelUnityOfWork = consumivelUnityOfWork;
        }
    }
}
