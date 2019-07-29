using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorMotorista
    {
        void Alterar(MotoristaModel motoristaModel);
        int Cadastrar(MotoristaModel motoristaModel);
        MotoristaModel Buscar(int id);
        void Remover(int id);
        IEnumerable<MotoristaModel> ObterTodos();

    }
}