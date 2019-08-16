using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModel
{
    public class ViagemPassagemViewModel
    {
        public RotaModel Rota { get; set; }
        public ViagemModel Viagem { get; set; }
        public SolicitacaoVeiculoModel Solicitacao { get; set; }
    }
}
