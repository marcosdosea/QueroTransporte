
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class PagamentoPassagemModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data pagamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}