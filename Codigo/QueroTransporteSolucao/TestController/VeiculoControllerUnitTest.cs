using Business;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using QueroTransporte.QueroTransporteWeb;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestController
{
    public class VeiculoControllerUnitTest
    {

        [Fact]
        public void IndexTest()
        {
            var mockRepoVeiculos = new Mock<GerenciadorVeiculo>();
            var mockRepoFrotas = new Mock<GerenciadorFrota>();

            mockRepoVeiculos.Setup(repo => repo.ObterTodos()).Returns(GetTestVeiculos());
            mockRepoFrotas.Setup(repo => repo.ObterTodos()).Returns(GetTestFrotas());


            var controller = new VeiculoController( mockRepoVeiculos.Object, mockRepoFrotas.Object);
            
            var result =  controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<VeiculoModel>>(viewResult.ViewData.Model);


            Assert.Equal(2, model.Count);
        }
        
        [Fact]
        public void InserirVeiculoInvalido() {
            var mockRepoVeiculos = new Mock<GerenciadorVeiculo>();
            var mockRepoFrotas = new Mock<GerenciadorFrota>();


            var controller = new VeiculoController(mockRepoVeiculos.Object, mockRepoFrotas.Object);
            controller.ModelState.AddModelError("IdFrota", "Required");
            controller.ModelState.AddModelError("Placa", "Required");
            controller.ModelState.AddModelError("Marca", "Required");
            controller.ModelState.AddModelError("Modelo", "Required");
            controller.ModelState.AddModelError("Cor", "Required");
            controller.ModelState.AddModelError("AnoFabricacao", "Required");
            controller.ModelState.AddModelError("AnoModelo", "Required");
            controller.ModelState.AddModelError("DataEmplacamento", "Required");
            controller.ModelState.AddModelError("Chassi", "Required");
            controller.ModelState.AddModelError("Categoria", "Required");
            controller.ModelState.AddModelError("Capacidade", "Required");

            var veiculo = GetTestVeiculo();

            var result = controller.Create(veiculo);

            // Assert
            var badRequestResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<VeiculoModel>(badRequestResult.Model);
        }

        [Fact]
        public void InserirVeiculoValido()
        {
            var mockRepoVeiculos = new Mock<GerenciadorVeiculo>();
            var mockRepoFrotas = new Mock<GerenciadorFrota>();

            mockRepoVeiculos.Setup(repo => repo.Inserir(It.IsAny<VeiculoModel>())).Verifiable();
            //mockRepoFrotas.Setup(repo => repo.ObterTodos()).Returns(GetTestFrotas());

            var controller = new VeiculoController(mockRepoVeiculos.Object,mockRepoFrotas.Object);

            var result = controller.Create(GetTestVeiculo());

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepoVeiculos.Verify();
        }

        [Fact]
        public void EditarVeiculoValido()
        {
            var mockRepoVeiculos = new Mock<GerenciadorVeiculo>();
            var mockRepoFrotas   = new Mock<GerenciadorFrota>();

            
            mockRepoVeiculos.Setup(repo => repo.ObterPorId(It.IsAny<int>())).Returns(GetTestVeiculo());
            mockRepoFrotas.Setup(repo => repo.ObterTodos()).Returns(GetTestFrotas());

            var controller = new VeiculoController(mockRepoVeiculos.Object, mockRepoFrotas.Object);

            var veiculo = GetTestVeiculo();
            var result = controller.Edit(veiculo.Id);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepoVeiculos.Verify();
        }

        private List<VeiculoModel> GetTestVeiculos()
        {
            return new List<VeiculoModel>()
            {

                new VeiculoModel()
                {
                    Id = 1,
                    IdFrota = 1,
                    Placa = "OCF2565",
                    Marca = "Volkswagen",
                    Modelo = "Volksbus 15.190 OD",
                    Cor = "Amarelo",
                    AnoFabricacao = "2010",
                    AnoModelo = "2011",
                    DataEmplacamento = DateTime.Now.Date,
                    Chassi = "9BWZZZ377VT004251",
                    Categoria = "D",
                    Capacidade = 42
                },
                new VeiculoModel()
                {
                    Id = 2,
                    IdFrota = 1,
                    Placa = "OCF2565",
                    Marca = "Volkswagen",
                    Modelo = "Volksbus 15.190 OD",
                    Cor = "Amarelo",
                    AnoFabricacao = "2010",
                    AnoModelo = "2011",
                    DataEmplacamento = DateTime.Now.Date,
                    Chassi = "9BWZZZ377VT004251",
                    Categoria = "D",
                    Capacidade = 42
                }
            };
        }

        private VeiculoModel GetTestVeiculo()
        {
            return new VeiculoModel()
            {
                    Id = 3,
                    IdFrota = 1,
                    Placa = "OCF2565",
                    Marca = "Volkswagen",
                    Modelo = "Volksbus 15.190 OD",
                    Cor = "Amarelo",
                    AnoFabricacao = "2010",
                    AnoModelo = "2011",
                    DataEmplacamento = DateTime.Now.Date,
                    Chassi = "9BWZZZ377VT004251",
                    Categoria = "D",
                    Capacidade = 42
            };
        }

        private List<FrotaModel> GetTestFrotas()
        {
            return new List<FrotaModel>()
            {

                new FrotaModel()
                {
                    Id = 1,
                    Titulo = "Frota de veiculos da prefeitura de itabaiana",
                    Descricao = "Responsavel por pegar os alunos da zona rural",
                    IsPublic = true
                },
                new FrotaModel()
                {
                    Id = 2,
                    Titulo = "Frota de veiculos da prefeitura de itabaiana",
                    Descricao = "Responsavel por pegar os alunos da zona rural",
                    IsPublic = true
                }
            };
        }
    }
}
