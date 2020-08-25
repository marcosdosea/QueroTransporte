using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IComprarCreditoRepository
    {
        bool Editar(CreditoViagemModel objeto);
        bool Inserir(CreditoViagemModel objeto);
        CreditoViagemModel ObterPorId(int id);
        List<CreditoViagemModel> ObterTodos();
        bool Remover(int id);
    }
}