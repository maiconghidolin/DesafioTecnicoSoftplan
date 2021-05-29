using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioSoftplanTest.IntegrationTests
{
    public class CalculaJurosControllerIntegrationTest : IClassFixture<WebApplicationFactory<DesafioSoftplan.Startup>>
    {

        private readonly HttpClient _client;
        private readonly WebApplicationFactory<DesafioSoftplan.Startup> _factory;

        public CalculaJurosControllerIntegrationTest(WebApplicationFactory<DesafioSoftplan.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Get_CalculaJuros_RetornaSucesso()
        {
            var request = "/CalculaJuros?valorinicial=100&meses=5";

            var response = await _client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_CalculaJuros_RetornaBadRequest()
        {
            var request = "/CalculaJuros?valorinicial=0&meses=0";

            var response = await _client.GetAsync(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_ShowMeTheCode_RetornaSucesso()
        {
            var request = "/ShowMeTheCode";

            var response = await _client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }

    }
}
