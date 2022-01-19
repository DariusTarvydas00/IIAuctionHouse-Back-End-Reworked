using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices.IEachUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Converters;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories.TreeTypeRepositories;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using IIAuctionHouse.Domain.Services;
using IIAuctionHouse.Domain.Services.ForestDetailServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices.EachUidRepositories;
using IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators;
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "IIAuctionHouse.WebApi", Version = "v1"});
                c.CustomSchemaIds(type => type.ToString());
            });

            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            services.AddDbContext<MainDbContext>(builder =>
                {
                    builder.UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=AuctionHouseDbContext.db");
                }, ServiceLifetime.Transient
            );
            services.AddScoped<IPercentageService, PercentageService>();
            services.AddScoped<IPercentageRepository, PercentageRepository>();
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<ITreeTypeService, TreeTypeService>();
            services.AddScoped<ITreeTypeRepository, TreeTypeRepository>();
            
            services.AddScoped<IPlotService, PlotService>();
            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<IForestService, ForestService>();
            services.AddScoped<IForestRepository, ForestRepository>();
            
            services.AddScoped<IForestEnterpriseService, ForestEnterpriseService>();
            services.AddScoped<IForestEnterpriseRepository, ForestEnterpriseRepository>();
            services.AddScoped<IForestGroupService, ForestGroupService>();
            services.AddScoped<IForestGroupRepository, ForestGroupRepository>();
            services.AddScoped<IForestLocationService, ForestLocationService>();
            
            services.AddScoped<IForestFirstUidService, ForestFirstUidService>();
            services.AddScoped<IForestFirstUidRepository, ForestFirstUidRepository>();
            services.AddScoped<IForestSecondUidService, ForestSecondUidService>();
            services.AddScoped<IForestSecondUidRepository, ForestSecondUidRepository>();
            services.AddScoped<IForestThirdUidService, ForestThirdUidService>();
            services.AddScoped<IForestThirdUidRepository, ForestThirdUidRepository>();
            
            services.AddScoped<IForestUidService, ForestUidService>();
            services.AddScoped<IForestUidRepository, ForestUidRepository>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IBidRepository, BidRepository>();
            
            services.AddScoped<PercentageConverter>();
            services.AddScoped<TreeConverter>();
            services.AddScoped<ForestUidFirstConverter>();
            services.AddScoped<ForestUidSecondConverter>();
            services.AddScoped<ForestUidThirdConverter>();
            services.AddScoped<ForestryEnterpriseConverter>();
            services.AddScoped<ForestGroupConverter>();
            services.AddScoped<ForestUidConverter>();
            services.AddScoped<TreeTypeConverter>();
            
            services.AddScoped<PercentageValidator>();
            services.AddScoped<TreeValidator>();
            services.AddScoped<PlotValidator>();
            
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "IIAuctionHouse.WebApi v1"));
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