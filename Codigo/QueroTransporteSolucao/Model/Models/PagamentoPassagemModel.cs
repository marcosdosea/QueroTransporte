
using System;

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