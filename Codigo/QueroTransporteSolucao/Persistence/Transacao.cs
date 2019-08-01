using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Transacao
    {
        public int Id { get; set; }
        public decimal QtdCreditos { get; set; }
        public byte Deferido { get; set; }
        public DateTime Data { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }

        public Usuario UsuarioNavigation { get; set; }
    }
}
