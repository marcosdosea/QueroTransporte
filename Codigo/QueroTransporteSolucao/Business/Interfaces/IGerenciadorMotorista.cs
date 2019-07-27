using QueroTransporte.Model;
using System.Collections.Generic;

namespace QueroTransporte.Negocio
{
    public interface IGerenciadorMotorista
    {
        void AlterarMotorista();
        int CadastrarMotorista(MotoristaModel motoristaModel);
        void ConfirmarCadastro();
        MotoristaModel ConsultarMotorista(int id);
        void RemoverMotorista();
        void ValidarMotorista();
    }
}