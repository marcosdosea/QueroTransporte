using AutoMapper;
using Data.Entities;
using Persistence;
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
            CreateMap<Motorista, MotoristaModel>().ReverseMap();
            CreateMap<Pagamento, PagamentoPassagemModel>().ReverseMap();
            CreateMap<Rota, RotaModel>().ReverseMap();
            CreateMap<RotaFrota, RotaFrotaModel>().ReverseMap();
            CreateMap<Solicitacao, SolicitacaoVeiculoModel>().ReverseMap();
            CreateMap<Transacao, TransacaoModel>().ReverseMap();
            CreateMap<Usuario, UsuarioModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoModel>().ReverseMap();
            CreateMap<Viagem, ViagemModel>().ReverseMap();
        }
    }
}
