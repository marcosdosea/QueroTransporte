using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorRota
    {
        // para usúários finais
        void ValidarDados(RotaModel Rota);

        // para administradores
        void Alterar(RotaModel Rota);
        RotaModel Buscar(int Id);
        void Excluir(int Id);
        int Inserir(RotaModel Rota);
        IEnumerable<RotaModel> ObterPorNome(string Destino);
        IEnumerable<RotaModel> ObterTodos();
        List<RotaModel> ObterDetalhesRota();
        RotaModel ObterDetalhesRota(int Id);
    }
}