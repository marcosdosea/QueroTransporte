using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Solicitacao
    {
        public int Id { get; set; }
        public int Viagem { get; set; }
        public int Usuario { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public byte FoiAtentida { get; set; }
        public int PagamentoId { get; set; }

        public Pagamento Pagamento { get; set; }
        public Usuario UsuarioNavigation { get; set; }
        public Viagem ViagemNavigation { get; set; }
    }
}
