
using System;
using System.ComponentModel.DataAnnotations;

namespace QueroTransporte.Model
{
    public class SolicitacaoVeiculoModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdViagem { get; set; }
        [Required]
        [Display(Name = "Data Solicitação Veiculo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataSolicitacao { get; set; }
        [Required]
        public bool IsAtendida { get; set; }
        public int IdPagamento { get; set; }
    }
}