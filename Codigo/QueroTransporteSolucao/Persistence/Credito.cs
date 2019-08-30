using System.ComponentModel.DataAnnotations;

namespace Persistence
{
    public partial class Credito
    {
        public int Id { get; set; }
        [Required]
        public decimal? Saldo { get; set; }
        [Required]
        public int IdUsuario { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
    }
}
