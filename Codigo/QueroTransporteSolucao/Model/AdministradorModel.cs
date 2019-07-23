
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class AdministradorModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}