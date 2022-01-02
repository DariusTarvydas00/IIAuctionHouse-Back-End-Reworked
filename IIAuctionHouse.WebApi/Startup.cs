using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailsRepositories;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace IIAuctionHouse.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "IIAuctionHouse.WebApi", Version = "v1"});
            });

            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            services.AddDbContext<MainDbContext>(builder =>
                {
                    builder.UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=AuctionHouseDbContext.db");
                }, ServiceLifetime.Transient
            );
            services.AddScoped<IForestService, ForestService>();
            services.AddScoped<IForestRepository, ForestRepository>();
            services.AddScoped<IPlotService, PlotService>();
            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<ITreeTypeService, TreeTypeService>();
            services.AddScoped<ITreeTypeRepository, TreeTypeRepository>();
            
            services.AddScoped<IPercentageService, PercentageService>();
            services.AddScoped<IPercentageRepository, PercentageRepository>();
            
            services.AddScoped<IMainDbContextSeeder, MainDbContextSeeder>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                options.AddPolicy("Prod-cors", policy =>
                {
                    policy
                        .WithOrigins(
                            "https://legosforlife2021.firebaseapp.com",
                            "https://legosforlife2021.web.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                } );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMainDbContextSeeder mainDbContextSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IIAuctionHouse.WebApi v1"));
                app.UseCors("Dev-cors");
                mainDbContextSeeder.SeedDevelopment();
            }
            else
            {
                app.UseCors("Prod-cors");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}