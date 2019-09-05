using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class GestorModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}