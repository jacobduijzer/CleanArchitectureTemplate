using System.Reflection;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Blazor
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) =>
            _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("in-mem-prod-database");
                    options.EnableSensitiveDataLogging(true);
                })
                .AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>()
                .AddScoped<IRepository<ToDoItem>, EfRepository<ToDoItem>>()
                .AddMediatR(cfg => cfg.AsScoped(), typeof(ToDoItemsQueryHandler).GetTypeInfo().Assembly)
                .AddRazorPages();

            services.AddServerSideBlazor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // SEED WITH TEST DATA
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<AppDbContext>();
                context.Seed();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}