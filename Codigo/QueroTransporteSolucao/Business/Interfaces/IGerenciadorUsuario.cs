namespace QueroTransporte.Negocio
{
    public interface IGerenciadorUsuario
    {
        void Alterar();
        void Autenticar();
        void buscar();
        void Cadastrar();
        void RemoverCliente();
        void Validar();
        void ValidarDados();
    }
}