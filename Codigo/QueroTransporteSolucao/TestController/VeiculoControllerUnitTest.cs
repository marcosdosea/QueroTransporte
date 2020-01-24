using Moq;
using QueroTransporte.Negocio;
using System;
using Xunit;

namespace TestController
{
    public class VeiculoControllerUnitTest
    {
        [Fact]
        public void Index()
        {
            var mockRepo = new Mock<GerenciadorVeiculo>();

           // mockRepo.Setup(repo => repo.ObterTodos()).
           //     Returns(GetTestVeiculos());
        }
    }
}
