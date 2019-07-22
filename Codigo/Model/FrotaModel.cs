
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class FrotaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [MaxLength(400)]
        public string Descricao { get; set; }
        [Required]
		[Display(Name = "Rota Publica")]
        public bool IsPublic { get; set; }
    }
}