using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.DataAccess.Repositories.ForestRepositories;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;
using IIAuctionHouse.Domain.Services;
using IIAuctionHouse.Domain.Services.ForestServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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
            services.AddScoped<IForestLocationService, ForestLocationService>();
            services.AddScoped<IForestLocationRepo, ForestLocationRepository>();
            services.AddScoped<ITreeGroupService, TreeGroupService>();
            services.AddScoped<ITreeGroupRepo, TreeGroupRepository>();
            services.AddScoped<ITreeTypeService, TreeTypeService>();
            services.AddScoped<ITreeTypeRepo, TreeTypeRepository>();
            services.AddScoped<IForestService, ForestService>();
            services.AddScoped<IForestRepo, ForestRepository>();
            
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