using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorRota
    {
        // para usúários finais
        void Consultar(RotaModel rotaModel);
        void ValidarDados(RotaModel rotaModel);

        // para administradores
        void Alterar(RotaModel rotaModel);
        RotaModel Buscar(int id);
        void Excluir(int Id);
        int Inserir(RotaModel rotaModel);
        IEnumerable<RotaModel> ObterPorNome(string rota);
        IEnumerable<RotaModel> ObterTodos();
        List<RotaModel> ToSelectList();
    }
}