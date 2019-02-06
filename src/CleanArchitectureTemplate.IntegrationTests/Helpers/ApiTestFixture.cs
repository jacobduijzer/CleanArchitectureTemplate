using System;
using System.Net.Http;
using CleanArchitectureTemplate.Api;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using CleanArchitectureTemplate.IntegrationTests.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class ApiTestFixture : IDisposable
    {
        public readonly HttpClient HttpClient;
        public readonly IApiDefinition Api;

        public ApiTestFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                 .UseInMemoryDatabase(databaseName: "in-mem-api-test-database")
                 .Options;

            var appDbContext = new AppDbContext(options);
            appDbContext.ToDoItems.AddRange(ToDoItemData.ToDoItemsForTesting);
            appDbContext.SaveChanges();

            var server = new TestServer(new WebHostBuilder()
            .UseEnvironment(EnvironmentName.Development)
            .ConfigureTestServices((IServiceCollection serviceCollection) =>
            {
                // Use stubbed database for integration tests
                serviceCollection.AddSingleton<AppDbContext>(x => appDbContext);
                serviceCollection.AddSingleton<IRepository<ToDoItem>, EfRepository<ToDoItem>>();
            })
            .UseStartup<Startup>());

            HttpClient = server.CreateClient();
            Api = RestService.For<IApiDefinition>(HttpClient);
        }

        public void Dispose()
        {
        }
    }
}
