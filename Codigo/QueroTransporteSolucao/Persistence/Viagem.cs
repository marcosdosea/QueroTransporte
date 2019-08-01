using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Viagem
    {
        public Viagem()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int Id { get; set; }
        public int Rota { get; set; }
        public int Veiculo { get; set; }
        public double Preco { get; set; }
        public int Lotacao { get; set; }
        public byte FoiRealizada { get; set; }

        public Rota RotaNavigation { get; set; }
        public Veiculo VeiculoNavigation { get; set; }
        public ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
