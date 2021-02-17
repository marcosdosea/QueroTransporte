using System.Collections.Generic;

namespace Data.Entities
{
    public partial class RelatorioMecanico
    {
        public RelatorioMecanico()
        {
            ProximasTrocas = new HashSet<ProximasTrocas>();
            SolicitacoesManutencao = new HashSet<SolicitacoesManutencao>();
        }

        public int Id { get; set; }
        public byte[] OrdemServico { get; set; }
        public string Descricao { get; set; }
        public decimal? ValorPecas { get; set; }
        public decimal? ValorServico { get; set; }
        public decimal? ValorTotal { get; set; }

        public ICollection<ProximasTrocas> ProximasTrocas { get; set; }
        public ICollection<SolicitacoesManutencao> SolicitacoesManutencao { get; set; }
    }
}
