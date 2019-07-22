
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class ConsumivelVeicularModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdVeiculo { get; set; }
        [Required]
        [Display(Name = "Custo")]
        public double Valor { get; set; }
        [Required]
        [Display(Name = "Emplacamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDespesa { get; set; }
        [Required]
        [MaxLength(20), MinLength(3)]
        public string Categoria { get; set; }
    }
}