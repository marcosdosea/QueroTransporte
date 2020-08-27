using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class VeiculoUnityOfWork : IVeiculoUnityOfWork
    {
        public IVeiculoRepository VeiculoRepository { get; }
        public VeiculoUnityOfWork(IVeiculoRepository gerenciadorVeiculo)
        {
            VeiculoRepository = gerenciadorVeiculo;
        }
    }
}
