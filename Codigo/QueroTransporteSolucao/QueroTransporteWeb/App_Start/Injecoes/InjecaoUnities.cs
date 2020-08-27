using Data.Repositories;
using Data.UnitiesOfWork;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace QueroTransporteWeb.App_Start.Injecoes
{
    public static class InjecaoUnities
    {
        public static void InjetarUnities(IServiceCollection services)
        {
            services.AddScoped<IFrotaUnityOfWork, FrotaUnityOfWork>();
            services.AddScoped<IMotoristaUnityOfWork, MotoristaUnityOfWork>();
            services.AddScoped<IRotaUnityOfWork, RotaUnityOfWork>();
            services.AddScoped<IUsuarioUnityOfWork, UsuarioUnityOfWork>();
            services.AddScoped<IVeiculoUnityOfWork, VeiculoUnityOfWork>();
            services.AddScoped<IViagemUnityOfWork, ViagemUnityOfWork>();
            services.AddScoped<IConsumivelUnityOfWork, ConsumivelIUnityOfWork>();
            services.AddScoped<ICreditoUnityOfWork, CreditoUnityOfWork>();
            services.AddScoped<IFrotaUnityOfWork, FrotaUnityOfWork>();
            services.AddScoped<ISolicitacaoUnityOfWork, SolicitacaoUnityOfWork>();
            services.AddScoped<IPagarPassagemRepository, PagarPassagemRepository>();
            services.AddScoped<IPagamentoUnityOfWork, PagamentoUnityOfWork>();
            services.AddScoped<ITransacaoUnityOfWork, TransacaoUnityOfWork>();
        }
    }
}
