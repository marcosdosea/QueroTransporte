
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
        [Required(ErrorMessage = "Todo veículo deve pertencer a uma frota. (CSU ainda não implementado, cadastrar frotas manualmente).")]
        [Display(Name = "Frota")]
        public int IdFrota { get; set; }
        [Required]
        [Display(Name = "Placa")]
        [MaxLength(7)]
        public string Placa { get; set; }
        [Required]
        [Display(Name = "Marca")]
        [MaxLength(30)]
        public string Marca { get; set; }
        [Required]
        [Display(Name = "Modelo")]
        [MaxLength(30)]
        public string Modelo { get; set; }
        [Required]
        [Display(Name = "Cor")]
        [MaxLength(20)]
        public string Cor { get; set; }
        [Required]
        [Display(Name = "Ano Fabricação")]
        [MaxLength(4)]
        public string AnoFabricacao { get; set; }
        [Required]
        [Display(Name = "Ano Modelo")]
        [MaxLength(4)]
        public string AnoModelo { get; set; }
        [Required]
        [Display(Name = "Emplacamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmplacamento { get; set; }
        [Required]
        [Display(Name = "Chassi")]
        [MaxLength(50)]
        public string Chassi { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        [MaxLength(20)]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Capacidade")]
        public int Capacidade { get; set; }
    }
}