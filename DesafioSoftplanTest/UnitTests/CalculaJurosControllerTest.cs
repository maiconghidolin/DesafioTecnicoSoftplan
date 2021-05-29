using DesafioSoftplan.Controllers;
using DesafioSoftplan.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DesafioSoftplanTest.UnitTests
{
    public class CalculaJurosControllerTest
    {

        private Mock<IJurosService> _mockService;
        private CalculaJurosController _controller;

        public CalculaJurosControllerTest()
        {
            _mockService = new Mock<IJurosService>();
            _mockService.Setup(p => p.GetTaxaJuros()).Returns(0.01);
            _controller = new CalculaJurosController(_mockService.Object);
        }

        [Fact]
        public void CalculaJuros_ValorNegativo_RetornaBadRequest()
        {
            var valorInicial = -1;
            var meses = 5;

            var badResponse = _controller.CalculaJuros(valorInicial, meses);

            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }

        [Fact]
        public void CalculaJuros_MesNegativo_RetornaBadRequest()
        {
            var valorInicial = 100;
            var meses = -5;

            var badResponse = _controller.CalculaJuros(valorInicial, meses);

            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }

        [Fact]
        public void CalculaJuros_QuandoChamado_RetornaOk()
        {     
            var valorInicial = 100;
            var meses = 5;
          
            var okResult = _controller.CalculaJuros(valorInicial, meses);
           
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void CalculaJuros_QuandoChamado_RetornaTaxaCerta()
        {          
            var valorInicial = 100;
            var meses = 5;
            
            var okResult = _controller.CalculaJuros(valorInicial, meses).Result as OkObjectResult;
            
            Assert.IsType<String>(okResult.Value);
            Assert.Equal("105,10", okResult.Value);
        }

        [Fact]
        public void ShowMeTheCode_QuandoChamado_RetornaOk()
        {
            var okResult = _controller.ShowMeTheCode();
         
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void ShowMeTheCode_QuandoChamado_RetornaLinkCerto()
        {
            var okResult = _controller.ShowMeTheCode().Result as OkObjectResult;
 
            Assert.IsType<String>(okResult.Value);
            Assert.Equal("https://github.com/maiconghidolin/DesafioTecnicoSoftplan", okResult.Value);
        }

    }
}
