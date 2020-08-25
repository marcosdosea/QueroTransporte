using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Viagem
    {
        public Viagem()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int Id { get; set; }
        public int IdRota { get; set; }
        public int IdVeiculo { get; set; }
        public double Preco { get; set; }
        public int Lotacao { get; set; }
        public byte FoiRealizada { get; set; }

        public Rota IdRotaNavigation { get; set; }
        public Veiculo IdVeiculoNavigation { get; set; }
        public ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
