
using System;
using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class MotoristaModel
    {
        public object id;

        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categoria CNH")]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Validade CNH")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Validade { get; set; }
        [Required]
        [MaxLength(12)]
        [Display(Name = "Numero CNH")]
        public string Cnh { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}