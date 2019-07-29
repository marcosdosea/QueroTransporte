using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorRota
    {
        // para usúários finais
        void ValidarDados(RotaModel rotaModel);

        // para administradores
        void Alterar(RotaModel rotaModel);
        RotaModel Buscar(int id);
        bool Excluir(int id);
        int Inserir(RotaModel rotaModel);
        IEnumerable<RotaModel> ObterPorNome(string destino);
        IEnumerable<RotaModel> ObterTodos();
        List<RotaModel> ObterDetalhesRota();
        RotaModel ObterDetalhesRota(int id);
    }
}