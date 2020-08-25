using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface ISolicitacaoRepository
    {
        bool Editar(SolicitacaoVeiculoModel objeto);
        bool Inserir(SolicitacaoVeiculoModel objeto);
        SolicitacaoVeiculoModel ObterPorId(int id);
        SolicitacaoVeiculoModel ObterPorViagemUsuario(int idUsuario, int idViagem, int isAtendida = 0);
        List<SolicitacaoVeiculoModel> ObterSolicitacoesAbertasPorUsuario(int idUsuario);
        List<SolicitacaoVeiculoModel> ObterTodos();
        List<SolicitacaoVeiculoModel> ObterTodosAtendidas(bool atendida);
        bool Remover(int id);
    }
}