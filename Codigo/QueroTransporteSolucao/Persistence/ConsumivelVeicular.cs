using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class ConsumivelVeicular
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Categoria { get; set; }
        public int Veiculo { get; set; }

        public virtual Veiculo VeiculoNavigation { get; set; }
    }
}
