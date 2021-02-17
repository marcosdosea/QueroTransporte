using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Veiculos
    {
        public Veiculos()
        {
            Abastecimento = new HashSet<Abastecimento>();
            ConsumivelVeicular = new HashSet<ConsumivelVeicular>();
            ProximasTrocas = new HashSet<ProximasTrocas>();
            RegistroSaidas = new HashSet<RegistroSaidas>();
            SolicitacoesManutencao = new HashSet<SolicitacoesManutencao>();
            Viagem = new HashSet<Viagem>();
            Vistorias = new HashSet<Vistorias>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }
        public DateTime DataEmplacamento { get; set; }
        public string Chassi { get; set; }
        public string Categoria { get; set; }
        public int Capacidade { get; set; }
        public int IdFrota { get; set; }
        public string NomeclaturaViatura { get; set; }
        public int? LeituraOdômetro { get; set; }
        public string Renavam { get; set; }
        public DateTime? VencimentoIpva { get; set; }
        public decimal? ValorVeiculo { get; set; }
        public string Status { get; set; }

        public Frota IdFrotaNavigation { get; set; }
        public ICollection<Abastecimento> Abastecimento { get; set; }
        public ICollection<ConsumivelVeicular> ConsumivelVeicular { get; set; }
        public ICollection<ProximasTrocas> ProximasTrocas { get; set; }
        public ICollection<RegistroSaidas> RegistroSaidas { get; set; }
        public ICollection<SolicitacoesManutencao> SolicitacoesManutencao { get; set; }
        public ICollection<Viagem> Viagem { get; set; }
        public ICollection<Vistorias> Vistorias { get; set; }
    }
}
