using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Motorista
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public DateTime Validade { get; set; }
        public string Cnh { get; set; }
        public int Usuario { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
