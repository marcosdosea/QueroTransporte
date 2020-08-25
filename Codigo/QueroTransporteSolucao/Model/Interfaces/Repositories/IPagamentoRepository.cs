using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IPagamentoRepository
    {
        bool Editar(PagamentoPassagemModel objeto);
        bool Inserir(PagamentoPassagemModel objeto);
        PagamentoPassagemModel ObterPorId(int id);
        List<PagamentoPassagemModel> ObterTodos();
        bool Remover(int id);
    }
}