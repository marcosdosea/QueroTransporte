﻿using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Rota
    {
        public Rota()
        {
            RotaFrota = new HashSet<RotaFrota>();
            Viagem = new HashSet<Viagem>();
        }

        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public TimeSpan HorarioSaida { get; set; }
        public TimeSpan HorarioChegada { get; set; }
        public string DiaSemana { get; set; }
        public byte EhComposta { get; set; }

        public ICollection<RotaFrota> RotaFrota { get; set; }
        public ICollection<Viagem> Viagem { get; set; }
    }
}
