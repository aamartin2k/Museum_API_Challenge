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

        // This method gets called by the runtime. Use this method to add services to the container.
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

            services.AddScoped<IMuseumService, MuseumService>();
            services.AddScoped<IArticleService, ArticleService>();


            // Mapper
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
