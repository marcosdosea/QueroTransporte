
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class TransacaoModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Saldo de Créditos")]
        public double QtdCreditos { get; set; }
        [Required]
        [Display(Name = "Status Pagamento")]
        public bool Deferido { get; set; }
        [Required]
        [Display(Name = "Data Pagamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [MaxLength(45)]
        public int Status { get; set; }
        // 0 = Cancelado, 1 = Pendente, 2 = Aprovado
    }
}