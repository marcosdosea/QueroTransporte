using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class RotaFrotaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdFrota { get; set; }
        [Required]
        public int IdRota { get; set; }
    }
}