using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Hosting;
#if (IncludeSampleCode)
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
#endif

namespace CleanArchitectureTemplate.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) =>
            _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("in-mem-prod-database");
                    options.EnableSensitiveDataLogging(true);
                })
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;

                })
                .AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>()
#if (IncludeSampleCode)
                .AddScoped<IRepository<ToDoItem>, EfRepository<ToDoItem>>()
                .AddMediatR(cfg => cfg.AsScoped(), typeof(ToDoItemsQueryHandler).GetTypeInfo().Assembly)
#endif
                .AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}
