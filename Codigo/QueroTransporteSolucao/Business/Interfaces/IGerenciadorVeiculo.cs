using System.Collections.Generic;
using QueroTransporte.Model;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorVeiculo
    {
        void Alterar(VeiculoModel Veiculo);
        VeiculoModel Buscar(int Id);
        void Excluir(int Id);
        int Inserir(VeiculoModel Veiculo);
        IEnumerable<VeiculoModel> ObterPorModelo(string Modelo);
        IEnumerable<VeiculoModel> ObterTodos();
    }
}