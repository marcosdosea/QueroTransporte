using System.Collections.Generic;
using QueroTransporte.Model;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorVeiculo
    {
        void Alterar(VeiculoModel veiculoModel);
        VeiculoModel Buscar(int id);
        void Excluir(int Id);
        int Inserir(VeiculoModel veiculoModel);
        IEnumerable<VeiculoModel> ObterPorNome(string modelo);
        IEnumerable<VeiculoModel> ObterTodos();
    }
}