using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestGroupRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories;
using IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.TreeTypeRepositories.TTRepositories;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories;
using IIAuctionHouse.Domain.Services;
using IIAuctionHouse.Domain.Services.ForestDetailServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.ForestGroupServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.ForestGroupServices.GroupServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices.UidServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.TreeTypeServices;
using IIAuctionHouse.Domain.Services.ForestDetailServices.TreeTypeServices.TTServices;
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
            
            services.AddScoped<IPlotService, PlotService>();
            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<IForestService, ForestService>();
            services.AddScoped<IForestRepository, ForestRepository>();
            
            services.AddScoped<IForestEnterpriseService, ForestryEnterpriseService>();
            services.AddScoped<IForestryEnterpriseRepository, ForestryEnterpriseRepository>();
            
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ISubGroupService, SubGroupService>();
            services.AddScoped<ISubGroupRepository, SubGroupRepository>();
            
            services.AddScoped<IForestGroupSubGroupService, ForestGroupSubGroupService>();
            
            services.AddScoped<IForestFirstUidService, FirstUidService>();
            services.AddScoped<IForestSecondUidService, SecondUidService>();
            services.AddScoped<IForestThirdUidService, ThirdUidService>();
            services.AddScoped<IForestFirstUidRepository, ForestFirstUidRepository>();
            services.AddScoped<IForestSecondUidRepository, ForestSecondUidRepository>();
            services.AddScoped<IForestThirdUidRepository, ForestThirdUidRepository>();
            
            services.AddScoped<IForestUidService, ForestUidService>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IBidRepository, BidRepository>();

            
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