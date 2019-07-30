using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Rota
    {
        public Rota()
        {
            InverseRotaNavigation = new HashSet<Rota>();
            RotaFrota = new HashSet<RotaFrota>();
            Viagem = new HashSet<Viagem>();
        }

        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public TimeSpan HorarioSaida { get; set; }
        public TimeSpan HorarioChegada { get; set; }
        public string DiaSemana { get; set; }
        public int? RotaId { get; set; }
        public bool EhComposta { get; set; }

        public virtual Rota RotaNavigation { get; set; }
        public virtual ICollection<Rota> InverseRotaNavigation { get; set; }
        public virtual ICollection<RotaFrota> RotaFrota { get; set; }
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
