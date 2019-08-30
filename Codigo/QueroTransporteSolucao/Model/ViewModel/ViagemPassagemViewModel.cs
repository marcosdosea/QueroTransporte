using QueroTransporte.Model;

namespace Model.ViewModel
{
    public class ViagemPassagemViewModel
    {
        public RotaModel Rota { get; set; }
        public ViagemModel Viagem { get; set; }
        public SolicitacaoVeiculoModel Solicitacao { get; set; }
        public CreditoViagemModel Creditos { get; set; }
        public bool EhCredito { get; set; }
    }
}
