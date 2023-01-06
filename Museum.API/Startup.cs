using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuseumAPI.Domain.Services;
using MuseumAPI.Persistence.Contexts;
using MuseumAPI.Services;
using AutoMapper;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Persistence.Repositories;

namespace MuseumAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("museum-api-in-memory");
            });

            // Register dependencies for injection
            services.AddScoped<IMuseumRepository, MuseumRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IMuseumThemeRepository, MuseumThemeRepository>();
            services.AddScoped<IArticleStatusRepository, ArticleStatusRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IMuseumService, MuseumService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IMuseumThemeService, MuseumThemeService>();
            services.AddScoped<IArticleStatusService, ArticleStatusService>();

            // Register Mapper
            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
