using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class ViagemRotaViewModel
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int IdVeiculo { get; set; }
        public int Preco { get; set; }
        public int Lotacao { get; set; }
        public bool IsRealizada { get; set; }
    }
}
