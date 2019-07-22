
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class RotaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Origem { get; set; }
        [Required]
        [MaxLength(30)]
        public string Destino { get; set; }
        [Required]
        [Display(Name = "Horario partida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HorarioSaida { get; set; }
        [Required]
        [Display(Name = "Horario chegada")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HorarioChegada { get; set; }
        [Required]
        public string DiaSemana { get; set; }
        [Required]
        public bool IsComposta { get; set; }
    }
}