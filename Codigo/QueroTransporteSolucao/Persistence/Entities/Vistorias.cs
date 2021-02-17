using System;

namespace Data.Entities
{
    public partial class Vistorias
    {
        public int Id { get; set; }
        public int MotoristaId { get; set; }
        public int VeiculoId { get; set; }
        public int? LeituraOdometro { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }

        public Motoristas Motorista { get; set; }
        public Veiculos Veiculo { get; set; }
    }
}
