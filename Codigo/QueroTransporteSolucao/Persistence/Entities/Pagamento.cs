using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Pagamento
    {
        public Pagamento()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }

        public ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
