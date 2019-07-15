
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo
{
    public class Rota
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double HorarioSaida { get; set; }
        public double HorarioChegada { get; set; }
        public string DiaSemana { get; set; }
        public bool IsComposta { get; set; }
    }
}