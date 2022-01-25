using System;
using System.Text;
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
using IIAuctionHouse.Security;
using IIAuctionHouse.Security.IRepositories;
using IIAuctionHouse.Security.IServices;
using IIAuctionHouse.Security.Repositories;
using IIAuctionHouse.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "AuctionHouse.WebApi", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
                services.AddAuthentication(authenticationOptions =>
                {
                    authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidateLifetime = true
                    };
                });
                var value = Configuration["JwtConfig:secret"];
                services.AddControllers();
                var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

                services.AddDbContext<MainDbContext>(
                    opt =>
                    {
                        opt.UseLoggerFactory(loggerFactory)
                            .UseSqlite("Data Source=honeyShop.db");
                    }, ServiceLifetime.Transient
                );

                services.AddDbContext<AuthDbContext>(
                    opt =>
                    {
                        opt.UseLoggerFactory(loggerFactory)
                            .UseSqlite("Data Source=honeyAuth.db");
                    }, ServiceLifetime.Transient
                );
                services.AddSwaggerGen(c =>
                {
                    c.CustomSchemaIds(type => type.ToString());
                });

                services.AddDbContext<MainDbContext>(builder =>
                    {
                        builder.UseLoggerFactory(loggerFactory)
                            .UseSqlite("Data Source=AuctionHouseDbContext.db");
                    }, ServiceLifetime.Transient
                );

                services.AddScoped<ISecurityService, SecurityService>();
                services.AddScoped<IAuthUserRepository, AuthUserRepository>();
                services.AddScoped<IAuthUserService, AuthUserService>();
                services.AddScoped<IAuthDbSeeder, AuthDbSeeder>();
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
                    });
                });
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                IMainDbContextSeeder mainDbContextSeeder, IAuthDbSeeder authDbSeeder)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "IIAuctionHouse.WebApi v1"));
                    app.UseCors("Dev-cors");
                    mainDbContextSeeder.SeedDevelopment();
                    authDbSeeder.SeedDevelopment();
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