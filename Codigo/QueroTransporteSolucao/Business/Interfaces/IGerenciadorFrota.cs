using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorFrota
    {
        void Alterar(FrotaModel frotaModel);
        FrotaModel Buscar(int id);
        void Excluir(int Id);
        int Inserir(FrotaModel frotaModel);
        IEnumerable<FrotaModel> ObterPorTitulo(string titulo);
        IEnumerable<FrotaModel> ObterTodos();



    }
}