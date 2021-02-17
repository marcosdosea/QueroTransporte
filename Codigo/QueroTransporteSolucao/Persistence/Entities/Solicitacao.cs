using System;

namespace Data.Entities
{
    public partial class Solicitacao
    {
        public int Id { get; set; }
        public int IdViagem { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public byte FoiAtentida { get; set; }
        public int IdPagamento { get; set; }

        public Pagamento IdPagamentoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public Viagem IdViagemNavigation { get; set; }
    }
}
