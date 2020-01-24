using Moq;
using QueroTransporte.Negocio;
using QueroTransporte.QueroTransporteWeb;
using System;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Index()
        {
            var mockRepoVeiculos = new Mock<GerenciadorVeiculo>();
            var mockRepoFrotas = new Mock<GerenciadorFrota>();

            mockRepoVeiculos.Setup(repo => repo.ObterTodos()).Returns(GetTestVeiculos());
            mockRepoFrotas.Setup(repo => repo.ObterTodos()).Returns(GetTestFrotas());

            var controller = new VeiculoController(mockRepoVeiculos.Object, mockRepoFrotas.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<VeiculoModel>>(viewResult.ViewData.Model);


            Assert.Equal(2, model.Count);
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
                    DataEmplacamento = DateTime.Now,
                    Chassi = "9BW ZZZ377 VT 004251",
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
                    DataEmplacamento = DateTime.Now,
                    Chassi = "9BW ZZZ377 VT 004251",
                    Categoria = "D",
                    Capacidade = 42
                }
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
