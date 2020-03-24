using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#if (IncludeSampleCode)
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
#endif


namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder) =>
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped((sp) =>
                {
                    var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseInMemoryDatabase("InMemoryDbTestName")
                        .Options;
                    var domainEventDispather = sp.GetService<IDomainEventsDispatcher>();
                    var mediator = sp.GetService<IMediator>();
                    var db = new AppDbContext(options, domainEventDispather, mediator);

                    db.Database.EnsureCreated();

#if (IncludeSampleCode)
                    db.SeedToDoItemsTestData();
#else
                    //db.SeedItemsTestData();
#endif

                    return db;
                });
            });
    }
}
