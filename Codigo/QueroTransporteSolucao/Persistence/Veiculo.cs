using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            ConsumivelVeicular = new HashSet<ConsumivelVeicular>();
            Viagem = new HashSet<Viagem>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }
        public DateTime DataEmplacamento { get; set; }
        public string Chassi { get; set; }
        public string Categoria { get; set; }
        public int Capacidade { get; set; }
        public int IdFrota { get; set; }

        public Frota IdFrotaNavigation { get; set; }
        public ICollection<ConsumivelVeicular> ConsumivelVeicular { get; set; }
        public ICollection<Viagem> Viagem { get; set; }
    }
}
