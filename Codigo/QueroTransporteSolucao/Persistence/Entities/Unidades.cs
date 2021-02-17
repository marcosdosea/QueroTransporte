using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Unidades
    {
        public Unidades()
        {
            RotaFrota = new HashSet<RotaFrota>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string NomeUnidade { get; set; }
        public string SiglaUnidade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public byte[] ArquivoFoto { get; set; }

        public ICollection<RotaFrota> RotaFrota { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
