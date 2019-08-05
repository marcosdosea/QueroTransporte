
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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
        public DateTime Validade { get; set; }
        [Required]
        [MaxLength(12)]
        [Display(Name = "Numero CNH")]
        public string Cnh { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
    }
}