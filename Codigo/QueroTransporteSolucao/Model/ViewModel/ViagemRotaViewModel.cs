using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class ViagemRotaViewModel
    {
        public RotaModel Rota { get; set; }
        public VeiculoModel Veiculo { get; set; }
        public ViagemModel Viagem { get; set; }
    }
}
