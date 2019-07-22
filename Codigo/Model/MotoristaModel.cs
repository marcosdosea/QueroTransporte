
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class MotoristaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categoria CNH")]
        public string Categoria { get; set; }
        [Required]
        public string Validade { get; set; }
        [Required]
        [Display(Name = "Numero CNH")]
        public string Cnh { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}