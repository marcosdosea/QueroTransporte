
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class MotoristaModel
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Validade { get; set; }
        public string Cnh { get; set; }
        public int IdUsuario { get; set; }
    }
}