using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioSoftplanTest.IntegrationTests
{
    public class TaxaJurosControllerIntegrationTest : IClassFixture<WebApplicationFactory<DesafioSoftplan.Startup>>
    {

        private readonly HttpClient _client;
        private readonly WebApplicationFactory<DesafioSoftplan.Startup> _factory;

        public TaxaJurosControllerIntegrationTest(WebApplicationFactory<DesafioSoftplan.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Get_TaxaJuros_RetornaSucesso()
        {
            var request = "/TaxaJuros";

            var response = await _client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }

    }
}
