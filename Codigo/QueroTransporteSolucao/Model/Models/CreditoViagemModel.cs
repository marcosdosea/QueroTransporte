using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class CreditoViagemModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}