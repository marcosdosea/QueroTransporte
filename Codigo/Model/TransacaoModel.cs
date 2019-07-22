
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public double QtdCreditos { get; set; }
        public bool Deferido { get; set; }
        public string Data { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }
    }
}