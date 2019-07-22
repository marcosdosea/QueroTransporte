namespace QueroTransporte.Negocio
{
    public interface IGerenciadorPagamento
    {
        void ConsultarHistoricoPagamento();
        void PagarPassagem();
    }
}