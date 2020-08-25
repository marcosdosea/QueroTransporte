using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class ClienteModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}