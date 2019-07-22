using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Solicitacao
    {
        public string Id { get; set; }
        public int Viagem { get; set; }
        public int Usuario { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public byte FoiAtentida { get; set; }
        public int PagamentoId { get; set; }

        public virtual Pagamento Pagamento { get; set; }
        public virtual Usuario UsuarioNavigation { get; set; }
        public virtual Viagem ViagemNavigation { get; set; }
    }
}
