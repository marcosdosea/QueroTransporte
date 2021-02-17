namespace Data.Entities
{
    public partial class ProximasTrocas
    {
        public int Id { get; set; }
        public string Especificacao { get; set; }
        public string KmProximaTroca { get; set; }
        public int VeiculosId { get; set; }
        public int RelatorioMecanicoId { get; set; }

        public RelatorioMecanico RelatorioMecanico { get; set; }
        public Veiculos Veiculos { get; set; }
    }
}
