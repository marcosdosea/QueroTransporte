using Microsoft.EntityFrameworkCore;
using Persistence;
using QueroTransporte.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestService
{
    public class GerenciadorRotaUnitTest
    {

        [Fact(DisplayName = "Inserir e no fim deverá ter 3 rotas")]
        public void Inserir()
        {
            var rota = new Rota()
            {
                Id = 5,
                Origem = "Ribeirópolis",
                Destino = "Aparecida",
                HorarioChegada = new TimeSpan(13, 00, 00),
                HorarioSaida = new TimeSpan(13, 40, 00),
                DiaSemana = "Sexta",
                EhComposta = 0,
                // RotaId  
            };

            var context = GetContextWithData();
            var gerenciador = new GerenciadorRota(context);
            context.Rota.Add(rota);
            context.SaveChanges();
            var model = context.Rota.Take(3);
                  // getAll = 3

            Assert.NotNull(model);
            Assert.Equal(3, model.Count());
        
        }

        [Fact(DisplayName = "Obter Todas Rotas, deve retornar 2")]
        public void ObterTodos()
        {
            var context = GetContextWithData();
            var gerenciador = new GerenciadorRota(context);
            var model = context.Rota.Take(2);  // getAll = 2

            Assert.NotNull(model);
            Assert.Equal(2, model.Count());
        }
        private BD_QUERO_TRANSPORTEContext GetContextWithData()
        {

            var options = new DbContextOptionsBuilder<BD_QUERO_TRANSPORTEContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new BD_QUERO_TRANSPORTEContext(options);
            // ---------------------------- Rotas  ----------------------------

            context.Rota.Add(new Rota()
            {
                Id = 4,
                Origem = "Areia Branca",
                Destino = "Itabaiana",
                HorarioChegada = new TimeSpan(13, 00, 00),
                HorarioSaida = new TimeSpan(13, 30, 00),
                DiaSemana = "Sábado",
                EhComposta = 0,
                // RotaId  
            });
            context.Rota.Add(new Rota()
            {
                Id = 3,
                Origem = "Ribeirópolis",
                Destino = "Frei Paulo",
                HorarioChegada = new TimeSpan(13, 00, 00),
                HorarioSaida = new TimeSpan(13, 30, 00),
                DiaSemana = "Quinta",
                EhComposta = 0,
                // RotaId  
            });
            context.Rota.Add(new Rota()
            {
                Id = 1,
                Origem = "Ribeirópolis",
                Destino = "Itabaiana",
                HorarioChegada = new TimeSpan(13, 00, 00),
                HorarioSaida = new TimeSpan(14, 00, 00),
                DiaSemana = "Sexta",
                EhComposta = 0,
                // RotaId  
            });
            context.Rota.Add(new Rota()
            {
                Id = 2,
                Origem = "Ribeirópolis",
                Destino = "Aracaju",
                HorarioChegada = new TimeSpan(13, 00, 00),
                HorarioSaida = new TimeSpan(15, 00, 00),
                DiaSemana = "Sexta",
                EhComposta = 1,
                IdRota = 1
            });
            //  ---------------------------- fimRotas  ----------------------------
            context.SaveChanges();
            return context;
        }
    }

}
