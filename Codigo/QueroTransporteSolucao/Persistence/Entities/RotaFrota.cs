namespace Data.Entities
{
    public partial class RotaFrota
    {
        public int Id { get; set; }
        public int IdRota { get; set; }
        public int UnidadesId { get; set; }

        public Frota IdNavigation { get; set; }
        public Rota IdRotaNavigation { get; set; }
        public Unidades Unidades { get; set; }
    }
}
