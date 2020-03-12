using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CleanArchitectureTemplate.Domain.Shared;

using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
#if (IncludeSampleCode)
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
#endif

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
#if (IncludeSampleCode)
                .AddScoped<IRepository<ToDoItem>, EfRepository<ToDoItem>>()
                .AddMediatR(cfg => cfg.AsScoped(), typeof(ToDoItemsQueryHandler).GetTypeInfo().Assembly)
#else
                //.AddScoped<IRepository<SomeModel>, EfRepository<SomeModel>>()
                //.AddMediatR(cfg => cfg.AsScoped(), typeof(SomeHandler).GetTypeInfo().Assembly)
#endif
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
#if (IncludeSampleCode)
                context.Seed();
#endif
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