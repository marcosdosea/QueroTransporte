using System;

namespace Data.Entities
{
    public partial class RegistroSaidas
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public int? LeituraOdometroInicial { get; set; }
        public TimeSpan? HorarioSaida { get; set; }
        public TimeSpan? HorarioRetorno { get; set; }
        public int? LeituraOdometroFinal { get; set; }
        public string Descricao { get; set; }
        public int MotoristaId { get; set; }
        public int VeiculoId { get; set; }

        public Motoristas Motorista { get; set; }
        public Veiculos Veiculo { get; set; }
    }
}
