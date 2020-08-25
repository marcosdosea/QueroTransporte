using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IConsumivelVeicularRepository
    {
        bool Editar(ConsumivelVeicularModel objeto);
        bool Inserir(ConsumivelVeicularModel objeto);
        ConsumivelVeicularModel ObterPorId(int idConsumivel);
        List<ConsumivelVeicularModel> ObterTodos();
        bool Remover(int id);
    }
}