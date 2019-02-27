using System;
using System.Net.Http;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using CleanArchitectureTemplate.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class WebTestFixture : IDisposable
    {
        public readonly HttpClient HttpClient;

        public WebTestFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                 .UseInMemoryDatabase(databaseName: "in-mem-web-test-database")
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
        }

        public void Dispose()
        {
        }
    }
}
