using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        bool Editar(VeiculoModel objeto);
        bool Inserir(VeiculoModel objeto);
        VeiculoModel ObterPorId(int idVeiculo);
        IEnumerable<VeiculoModel> ObterPorModelo(string modelo);
        List<VeiculoModel> ObterTodos();
        bool Remover(int id);
        bool VerificaEdicaoExistente(string chassi, string placa, int id);
        int VerificaInsercaoVeiculo(string chassi, string placa);
    }
}