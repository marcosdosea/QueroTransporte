using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        bool Editar(TransacaoModel objeto);
        bool Inserir(TransacaoModel objeto);
        TransacaoModel ObterPorId(int id);
        List<TransacaoModel> ObterTodasDeferidas(bool deferido);
        List<TransacaoModel> ObterTodos();
        List<TransacaoModel> ObterTodos(int idUsuario);
        bool Remover(int id);
    }
}