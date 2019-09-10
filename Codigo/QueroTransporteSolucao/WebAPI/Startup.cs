using Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using QueroTransporte.Negocio;
using System;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Gabriel",
                        ValidAudience = "Gabriel",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("Token invalido!!");
                            return Task.CompletedTask;
                        },

                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("TOKEN VALIDO");
                            return Task.CompletedTask;
                        }
                    };
                });



            services.AddDbContext<BD_QUERO_TRANSPORTEContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("QueroTransporteConnection")));

            // Gerenciadoras
            services.AddScoped<GerenciadorFrota>();
            services.AddScoped<GerenciadorMotorista>();
            services.AddScoped<GerenciadorRota>();
            services.AddScoped<GerenciadorUsuario>();
            services.AddScoped<GerenciadorVeiculo>();
            services.AddScoped<GerenciadorViagem>();
            services.AddScoped<GerenciadorConsumivelVeicular>();
            services.AddScoped<GerenciadorComprarCredito>();
            services.AddScoped<GerenciadorFrota>();
            services.AddScoped<GerenciadorSolicitacao>();
            services.AddScoped<GerenciadorPagarPassagem>();
            services.AddScoped<GerenciadorPagamento>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
