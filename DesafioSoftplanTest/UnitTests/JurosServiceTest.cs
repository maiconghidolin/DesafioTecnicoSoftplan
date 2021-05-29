using DesafioSoftplan.Interfaces;
using DesafioSoftplan.Services;
using Xunit;

namespace DesafioSoftplanTest.UnitTests
{
    public class JurosServiceTest
    {

        private IJurosService _jurosService;

        public JurosServiceTest()
        {
            _jurosService = new JurosService();
        }

        [Fact]
        public void GetTaxaJuros_QuandoChamado_RetornaTaxaCerta()
        {
            var taxaJuros = _jurosService.GetTaxaJuros();

            Assert.Equal(0.01, taxaJuros);
        }

    }
}
