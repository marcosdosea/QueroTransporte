using Data.Gerenciadoras;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace QueroTransporteWeb.App_Start.Injecoes
{
    public static class InjecaoGerenciadora
    {
        public static void InjetarGerenciadoras(IServiceCollection services)
        {
            services.AddScoped<IFrotaRepository, FrotaRepository>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IViagemRepository, ViagemRepository>();
            services.AddScoped<IConsumivelVeicularRepository, ConsumivelRepository>();
            services.AddScoped<IComprarCreditoRepository, ComprarCreditoRepository>();
            services.AddScoped<IFrotaRepository, FrotaRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
            services.AddScoped<IPagarPassagemRepository, PagarPassagemRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        }
    }
}
