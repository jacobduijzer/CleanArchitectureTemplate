using System.Net.Http;
using CleanArchitectureTemplate.IntegrationTests.Helpers;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Web
{
    public class BasePageTest<TStartup> : IClassFixture<CustomWebApplicationFactory<TStartup>> where TStartup : class
    {
        public readonly HttpClient HttpClient;

        public BasePageTest(CustomWebApplicationFactory<TStartup> factory) =>
            HttpClient = factory.CreateClient();
    }
}