
using System;
using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class MotoristaModel
    {

        public MotoristaModel() { }

        [Display(Name = "Codigo")]
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categoria CNH")]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Validade CNH")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Validade { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "Numero CNH")]
        public string Cnh { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}