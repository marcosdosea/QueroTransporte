using QueroTransporte.Model;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRotaRepository
    {
        bool Editar(RotaModel objeto);
        bool Inserir(RotaModel objeto);
        List<RotaModel> ObterDetalhesRota();
        RotaModel ObterDetalhesRota(int id);
        int ObterNumeroDeRotasDependentes(int id);
        RotaModel ObterPorId(int id);
        List<RotaModel> ObterPorNome(string destino);
        RotaModel ObterPorOrigemDestino(string origem, string destino);
        List<RotaModel> ObterPorOrigemDestino(string origem, string destino, string diaSemana);
        List<RotaModel> ObterTodos();
        bool Remover(int id);
    }
}