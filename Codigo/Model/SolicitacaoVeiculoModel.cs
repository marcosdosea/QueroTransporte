
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class SolicitacaoVeiculoModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdViagem { get; set; }
        public string DataSolicitacao { get; set; }
        public bool IsAtendida { get; set; }
    }
}