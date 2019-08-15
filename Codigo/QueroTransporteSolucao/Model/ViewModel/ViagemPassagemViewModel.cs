using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModel
{
    public class ViagemPassagemViewModel
    {
        [Key]
        [Required]
        public int IdViagemPassagem { get; set; }
        [Required]
        [MaxLength(30)]
        public string Origem { get; set; }
        [Required]
        [MaxLength(30)]
        public string Destino { get; set; }
        [Required]
        public double Preco { get; set; }
        public bool EhCredito { get; set; }
    }
}
