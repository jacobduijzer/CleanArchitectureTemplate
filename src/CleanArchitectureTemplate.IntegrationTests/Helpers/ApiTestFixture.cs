using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class ApiTestFixture : IDisposable
    {
        public readonly HttpClient HttpClient;

        public ApiTestFixture()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment(EnvironmentName.Development)
                .ConfigureTestServices((IServiceCollection serviceCollection) =>
                {
                    
                })
                .UseStartup<CleanArchitectureTemplate.Api.Startup>());

           HttpClient  = server.CreateClient();
        }

        public void Dispose()
        {
        }
    }
}
