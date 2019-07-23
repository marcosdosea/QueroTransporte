
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class ViagemModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdRota { get; set; }
        [Required]
        public int IdVeiculo { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public int Lotacao { get; set; }
        [Required]
        public bool IsRealizada { get; set; }
    }
}