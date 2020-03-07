using System;
using System.Reflection;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
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
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddSingleton<IDomainEventsDispatcher>(provider => new Mock<IDomainEventsDispatcher>().Object);
#if (IncludeSampleCode)
                services.AddScoped<IRepository<ToDoItem>, EfRepository<ToDoItem>>();
                services.AddMediatR(cfg => cfg.AsScoped(), typeof(ToDoItemsQueryHandler).GetTypeInfo().Assembly);
#else
                //services.AddScoped<IRepository<SomeModel>, EfRepository<SomeModel>>();
                //services.AddMediatR(cfg => cfg.AsScoped(), typeof(SomeHandler).GetTypeInfo().Assembly);
#endif

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
#if (IncludeSampleCode)
                        db.SeedToDoItemsTestData();
#else
                        //db.SeedItemsTestData();
#endif
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occured seeding the database with test data. Error: {ex.Message}");
                    }
                }
            });
    }
}