using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IFrotaRepository
    {
        bool Editar(FrotaModel objeto);
        bool Inserir(FrotaModel objeto);
        FrotaModel ObterPorId(int id);
        List<FrotaModel> ObterTodos();
        bool Remover(int id);
    }
}