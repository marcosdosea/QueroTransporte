using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Rota
    {
        public Rota()
        {
            InverseIdRotaNavigation = new HashSet<Rota>();
            Viagem = new HashSet<Viagem>();
        }

        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public TimeSpan HorarioSaida { get; set; }
        public TimeSpan HorarioChegada { get; set; }
        public int DiaSemana { get; set; }
        public int? IdRota { get; set; }
        public byte EhComposta { get; set; }

        public Rota IdRotaNavigation { get; set; }
        public ICollection<Rota> InverseIdRotaNavigation { get; set; }
        public ICollection<Viagem> Viagem { get; set; }
    }
}
