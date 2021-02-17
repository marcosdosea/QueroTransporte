namespace Data.Entities
{
    public partial class Credito
    {
        public int Id { get; set; }
        public decimal? Saldo { get; set; }
        public int IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
