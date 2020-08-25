using Data.Entities;

namespace Persistence
{
    public partial class RotaFrota
    {
        public int IdFrota { get; set; }
        public int IdRota { get; set; }

        public Frota IdFrotaNavigation { get; set; }
        public Rota IdRotaNavigation { get; set; }
    }
}
