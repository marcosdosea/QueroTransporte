using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;

namespace Data.UnitiesOfWork
{
    public class VeiculoUnityOfWork : IVeiculoUnityOfWork
    {
        public IVeiculoRepository GerenciadorVeiculo { get; }
        public VeiculoUnityOfWork(IVeiculoRepository gerenciadorVeiculo)
        {
            GerenciadorVeiculo = gerenciadorVeiculo;
        }
    }
}
