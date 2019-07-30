using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorViagem
    {
        bool Alterar(ViagemModel viagem);
        bool Inserir(ViagemModel viagem);
        List<ViagemModel> Buscar();
        ViagemModel BuscarPorId(int id);
        bool Excluir(int id);
    }
}