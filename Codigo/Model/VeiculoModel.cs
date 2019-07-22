
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class VeiculoModel
    {   
        [Required]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Frota")]
        public int IdFrota { get; set; }

        [Required]
        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Cor")]
        public string Cor { get; set; }

        [Required]
        [Display(Name = "Ano Fabricação")]
        public string AnoFabricacao { get; set; }

        [Required]
        [Display(Name = "Ano Modelo")]
        public string AnoModelo { get; set; }

        [Required]
        [Display(Name = "Emplacamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmplacamento { get; set; }

        [Required]
        [Display(Name = "Chassi")]
        public string Chassi { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required]
        [Display(Name = "Capacidade")]
        public int Capacidade { get; set; }
    }
}