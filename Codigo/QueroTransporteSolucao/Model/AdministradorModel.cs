using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class AdministradorModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}