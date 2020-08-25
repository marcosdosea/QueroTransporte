using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IMotoristaRepository
    {
        bool Editar(MotoristaModel objeto);
        bool Inserir(MotoristaModel objeto);
        MotoristaModel ObterPorId(int id);
        List<MotoristaModel> ObterTodos();
        bool Remover(int id);
    }
}