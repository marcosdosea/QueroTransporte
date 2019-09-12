using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModel
{
    public class RelatorioConsumivelVeicularViewModel
    {
        public double Valor { get; set; }
        public String Data { get; set; }
        public String ValorMasked{ get; set; }
    }
}
