using System;

namespace Data.Entities
{
    public partial class Abastecimento
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public int? LeituraOdometro { get; set; }
        public int? LitrosAbastecidos { get; set; }
        public string Abastecimentocol { get; set; }
        public int MotoristaId { get; set; }
        public int VeiculoId { get; set; }

        public Motoristas Motorista { get; set; }
        public Veiculos Veiculo { get; set; }
    }
}
