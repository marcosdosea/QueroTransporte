
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class ViagemModel
    {
        public int Id { get; set; }
        public int IdRota { get; set; }
        public int IdVeiculo { get; set; }
        public double Preco { get; set; }
        public int Lotacao { get; set; }
        public bool IsRealizada { get; set; }
    }
}