
using System;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "	{0:T}", ApplyFormatInEditMode = true)]
        public TimeSpan HorarioSaida { get; set; }
        [Required]
        [Display(Name = "Horario chegada")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "	{0:T}", ApplyFormatInEditMode = true)]
        public TimeSpan HorarioChegada { get; set; }
        [Required]
		[Display(Name = "Dia da Semana")]
        public string DiaSemana { get; set; }
        [Display(Name = "Rota Anterior")]
        public int? RotaId { get; set; }
        [Required]
		[Display(Name = "Rota Composta")]
        public bool IsComposta { get; set; }


        /* serve para concatenar informacoes como Origem,Destino e Id da para
         usuário selecionar a rota correta*/
        public string DetalhesRota { get; set; }
    }
}