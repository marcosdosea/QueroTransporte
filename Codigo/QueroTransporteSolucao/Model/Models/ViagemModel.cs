using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class ViagemModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Rota")]
        public int IdRota { get; set; }
        [Required]
        [Display(Name = "Placa Veículo")]
        public int IdVeiculo { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public int Lotacao { get; set; }
        [Required]
        [Display(Name = "Realizada?")]
        public bool IsRealizada { get; set; }
    }
}