using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Frota
    {
        public Frota()
        {
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte EhPublica { get; set; }

        public ICollection<Veiculo> Veiculo { get; set; }
    }
}
