using DesafioSoftplan.Controllers;
using DesafioSoftplan.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DesafioSoftplanTest.UnitTests
{
    public class TaxaJurosControllerTest
    {

        private Mock<IJurosService> _mockService;
        private TaxaJurosController _controller;

        public TaxaJurosControllerTest()
        {
            _mockService = new Mock<IJurosService>();
            _mockService.Setup(p => p.GetTaxaJuros()).Returns(0.01);
            _controller = new TaxaJurosController(_mockService.Object);
        }

        [Fact]
        public void TaxaJuros_QuandoChamado_RetornaOk()
        {
            var okResult = _controller.TaxaJuros();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void TaxaJuros_QuandoChamado_RetornaTaxaCerta()
        {
            var okResult = _controller.TaxaJuros().Result as OkObjectResult;
            
            Assert.IsType<String>(okResult.Value);
            Assert.Equal("0,01", okResult.Value);
        }

    }
}
