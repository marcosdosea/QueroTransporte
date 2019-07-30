using System.Collections.Generic;
using QueroTransporte.Model;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorVeiculo
    {
        void Alterar(VeiculoModel veiculoModel);
        VeiculoModel Buscar(int id);
        void Excluir(int id);
        int Inserir(VeiculoModel veiculoModel);
        IEnumerable<VeiculoModel> ObterPorModelo(string modelo);
        VeiculoModel ObterPorId(int idVeiculo);
        IEnumerable<VeiculoModel> ObterTodos();
        int VerificaInsercaoVeiculo(string chassi,string placa);
        bool VerificaEdicaoExistente(string chassi, string placa, int id);
    }
}