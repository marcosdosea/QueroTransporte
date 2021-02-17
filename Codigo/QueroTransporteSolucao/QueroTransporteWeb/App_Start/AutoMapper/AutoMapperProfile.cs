using AutoMapper;
using Data.Entities;
using QueroTransporte.Model;

namespace QueroTransporteWeb.App_Start.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ConsumivelVeicular, ConsumivelVeicularModel>().ReverseMap();
            CreateMap<Credito, CreditoViagemModel>().ReverseMap();
            CreateMap<Frota, FrotaModel>().ReverseMap();
            CreateMap<Motoristas, MotoristaModel>().ReverseMap();
            CreateMap<Pagamento, PagamentoPassagemModel>().ReverseMap();
            CreateMap<Rota, RotaModel>().ReverseMap();
            CreateMap<RotaFrota, RotaFrotaModel>().ReverseMap();
            CreateMap<Solicitacao, SolicitacaoVeiculoModel>().ReverseMap();
            CreateMap<Transacao, TransacaoModel>().ReverseMap();
            CreateMap<Usuarios, UsuarioModel>().ReverseMap();
            CreateMap<Veiculos, VeiculoModel>().ReverseMap();
            CreateMap<Viagem, ViagemModel>().ReverseMap();
        }
    }
}
