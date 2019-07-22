
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class RotaFrotaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdFrota { get; set; }
        [Required]
        public int IdRota { get; set; }
    }
}