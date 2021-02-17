using System;

namespace Data.Entities
{
    public partial class Transacao
    {
        public int Id { get; set; }
        public decimal? Valor { get; set; }
        public decimal QtdCreditos { get; set; }
        public byte Deferido { get; set; }
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
