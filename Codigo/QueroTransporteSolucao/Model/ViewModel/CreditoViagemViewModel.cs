using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class CreditoViagemViewModel
    {

        public int Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public CreditoViagemViewModel(int id, string descricao,double valor)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
        }
        public CreditoViagemViewModel()
        {

        }

    }
}
