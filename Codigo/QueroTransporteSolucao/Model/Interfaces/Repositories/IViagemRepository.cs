using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IViagemRepository
    {
        ViagemModel BuscarPorRota(int idRota);
        List<ViagemModel> BuscarPorRota(RotaModel rota);
        List<ViagemModel> BuscarPorVeiculo(VeiculoModel veiculo);
        bool Editar(ViagemModel viagem);
        bool Inserir(ViagemModel objeto);
        ViagemModel ObterPorId(int id);
        List<ViagemModel> ObterTodos();
        List<ViagemModel> ObterTodosAbertos(bool realizada);
        bool Remover(int id);
    }
}