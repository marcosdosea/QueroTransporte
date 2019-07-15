
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int IdFrota { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }
        public string DataEmplacamento { get; set; }
        public string Chassi { get; set; }
        public string Categoria { get; set; }
        public int Capacidade { get; set; }
    }
}