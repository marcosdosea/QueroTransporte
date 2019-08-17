
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class PagamentoPassagemModel
    {
        public int Id { get; set; }
       
        public DateTime Data { get; set; }

        public int Tipo { get; set; }
        // 1 = A vista, 2 = Credito;
    }
}