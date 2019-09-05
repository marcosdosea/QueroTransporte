using System.Collections.Generic;

namespace Persistence
{
    public partial class Frota
    {
        public Frota()
        {
            RotaFrota = new HashSet<RotaFrota>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte EhPublica { get; set; }

        public ICollection<RotaFrota> RotaFrota { get; set; }
        public ICollection<Veiculo> Veiculo { get; set; }
    }
}
