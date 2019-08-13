using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class CreditoViagemViewModel
    {

        public int Id { get; set; }

        public string Titulo { get; set; }

        public double Valor { get; set; }

        public CreditoViagemViewModel(int id, string titulo,double valor) {
            Id = id;
            Titulo = titulo;
            Valor = valor;
        }
    }
}
