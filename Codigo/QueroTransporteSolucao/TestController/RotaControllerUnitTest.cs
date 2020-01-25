using Microsoft.AspNetCore.Mvc;
using Moq;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using QueroTransporte.QueroTransporteWeb;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestController
{
    public class RotaControllerUnitTest
    {
        [Fact]
        public void Index()
        {
            var mockRepoRotas = new Mock<GerenciadorRota>();
           // var mockRepoFrotas = new Mock<GerenciadorFrota>();

            mockRepoRotas.Setup(repo => repo.ObterTodos()).Returns(GetTestRotas());
           // mockRepoFrotas.Setup(repo => repo.ObterTodos()).Returns(GetTestFrotas());

            var controller = new RotaController(mockRepoRotas.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<VeiculoModel>>(viewResult.ViewData.Model);


            Assert.Equal(2, model.Count);
        }


        private List<RotaModel> GetTestRotas()
        {
            return new List<RotaModel>()
            {

                new RotaModel()
                {
                    Id = 1,
                    Origem = "Ribeirópolis",
                    Destino = "Itabaiana",
                    HorarioChegada = new TimeSpan(13, 00, 00),
                    HorarioSaida =  new TimeSpan(14, 00, 00),
                    DiaSemana = "Sexta",
                    DetalhesRota = "Ribeirópolis, Itabaiana, 1",
                    IsComposta = false,
                   // RotaId  
                },
                new RotaModel()
                {
                    Id = 2,
                    Origem = "Ribeirópolis",
                    Destino = "Aracaju",
                    HorarioChegada = new TimeSpan(13, 00, 00),
                    HorarioSaida =  new TimeSpan(15, 00, 00),
                    DiaSemana = "Sexta",
                    DetalhesRota = "Ribeirópolis, Aracaju, 2",
                    IsComposta = true,
                    RotaId = 1
                }
            };
        }

       

    }

}
