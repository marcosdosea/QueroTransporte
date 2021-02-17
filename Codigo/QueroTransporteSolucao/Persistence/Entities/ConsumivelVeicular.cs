﻿using System;

namespace Data.Entities
{
    public partial class ConsumivelVeicular
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Categoria { get; set; }
        public int IdVeiculo { get; set; }

        public Veiculos IdVeiculoNavigation { get; set; }
    }
}
