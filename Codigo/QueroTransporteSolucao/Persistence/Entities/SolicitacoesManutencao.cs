using System;

namespace Data.Entities
{
    public partial class SolicitacoesManutencao
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int? LeituraOdometro { get; set; }
        public DateTime? Data { get; set; }
        public int TipoManutençãoId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public string Status { get; set; }
        public byte[] Arquivo { get; set; }
        public string NumeroSolicitacao { get; set; }
        public string RelatorioMecanico { get; set; }
        public int RelatorioMecanicoId { get; set; }

        public RelatorioMecanico RelatorioMecanicoNavigation { get; set; }
        public TiposManutencao TipoManutenção { get; set; }
        public Usuarios Usuario { get; set; }
        public Veiculos Veiculo { get; set; }
    }
}
