using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Credito
    {
        public int Id { get; set; }
        public decimal? Saldo { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
