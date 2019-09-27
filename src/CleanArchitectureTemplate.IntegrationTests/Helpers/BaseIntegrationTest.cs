using System.Net.Http;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class BaseIntegrationTest<TStartup> : IClassFixture<CustomWebApplicationFactory<TStartup>> where TStartup : class
    {
        public readonly HttpClient HttpClient;

        public BaseIntegrationTest(CustomWebApplicationFactory<TStartup> factory) =>
            HttpClient = factory.CreateClient();
    }
}