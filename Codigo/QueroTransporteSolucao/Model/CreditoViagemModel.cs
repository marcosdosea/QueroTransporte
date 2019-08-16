
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class CreditoViagemModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}