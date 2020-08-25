using Business;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace QueroTransporteWeb.App_Start.Injecoes
{
    public static class InjecaoServices
    {
        public static void InjetarServices(IServiceCollection services)
        {
            services.AddScoped<IFrotaService, FrotaService>();
            services.AddScoped<IMotoristaService, MotoristaService>();
            services.AddScoped<IRotaService, RotaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IViagemService, ViagemService>();
            services.AddScoped<IConsumivelService, ConsumivelService>();
            services.AddScoped<ICreditoService, CreditoService>();
            services.AddScoped<IFrotaService, FrotaService>();
            services.AddScoped<ISolicitacaoService, SolicitacaoService>();
            services.AddScoped<IPagarPassagemService, PagarPassagemService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
        }
    }
}
