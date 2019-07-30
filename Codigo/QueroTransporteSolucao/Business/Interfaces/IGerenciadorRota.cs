using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorRota
    {
        List<RotaModel> Consultar();
        RotaModel ObterPorId(int idRota);
        RotaModel ObterPorOrigemDestino(string origem, string destino);
        void ValidarDados();
    }
}