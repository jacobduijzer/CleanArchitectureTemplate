using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
#if (Api)
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
#endif

namespace CleanArchitectureTemplate.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Logging

            services
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("in-mem-prod-database");
                    options.EnableSensitiveDataLogging(true);
                })
                .AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>()
#if (Api)
                .AddScoped<IRepository<ToDoItem>, EfRepository<ToDoItem>>()
                .AddMediatR(cfg => cfg.AsScoped(), typeof(ToDoItemsQueryHandler).GetTypeInfo().Assembly)
#else
                //.AddScoped<IRepository<SomeModel>, EfRepository<SomeModel>>()
                //.AddMediatR(cfg => cfg.AsScoped(), typeof(SomeHandler).GetTypeInfo().Assembly)
#endif
                .AddSwaggerGen(config => config.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}))
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(config => config.MapControllers())
                .UseSwagger()
                .UseSwaggerUI(config => config.SwaggerEndpoint("v1/swagger.json", "API - V1"));
        }
    }
}
