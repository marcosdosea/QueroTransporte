using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TiposManutencao
    {
        public TiposManutencao()
        {
            SolicitacoesManutencao = new HashSet<SolicitacoesManutencao>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<SolicitacoesManutencao> SolicitacoesManutencao { get; set; }
    }
}
