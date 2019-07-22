namespace QueroTransporte.Negocio
{
    public interface IGerenciadorMotorista
    {
        void AlterarMotorista();
        void CadastrarMotorista();
        void ConfirmarCadastro();
        void ConsultarMotorista();
        void RemoverMotorista();
        void ValidarMotorista();
    }
}