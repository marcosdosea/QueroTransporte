
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class ConsumivelVeicularModel
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public double Valor { get; set; }
        public string DataDespesa { get; set; }
        public string Categoria { get; set; }
    }
}