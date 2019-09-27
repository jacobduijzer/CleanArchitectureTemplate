using System;
using System.Reflection;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

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
                services.AddScoped<IRepository<ToDoItem>, EfRepository<ToDoItem>>();
                services.AddMediatR(cfg => cfg.AsScoped(), typeof(ToDoItemsQueryHandler).GetTypeInfo().Assembly);

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        db.SeedToDoItemsTestData();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occured seeding the database with test data. Error: {ex.Message}");
                    }
                }
            });
    }
}