using System;

namespace Data.Entities
{
    public partial class Motorista
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public DateTime Validade { get; set; }
        public string Cnh { get; set; }
        public int IdUsuario { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
    }
}
