using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Frota
    {
        public Frota()
        {
            Veiculos = new HashSet<Veiculos>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte EhPublica { get; set; }

        public RotaFrota RotaFrota { get; set; }
        public ICollection<Veiculos> Veiculos { get; set; }
    }
}
