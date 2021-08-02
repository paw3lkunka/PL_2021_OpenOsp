using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;
using OpenOsp.Api.Services;
using Newtonsoft.Json.Serialization;

namespace OpenOsp {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      /// Load configuration files
      // services.Configure<Configuration>(Configuration.GetSection(""));
      /// Basic server configuration
      services.AddCors();
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      /// Database Context
      services.AddDbContext<AppDbContext>(options => {
        options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"), builder => {
          builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        }).EnableSensitiveDataLogging();
      });
      /// Identity users
      services.AddIdentityCore<User>(cfg => {
        cfg.User.RequireUniqueEmail = true;
        cfg.Password.RequireDigit = false;
        cfg.Password.RequireLowercase = false;
        cfg.Password.RequireUppercase = false;
        cfg.Password.RequireNonAlphanumeric = false;
        cfg.Password.RequiredLength = 12;
        cfg.SignIn.RequireConfirmedEmail = true;
      }).AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();
      /// Authentication with JWT
      services.AddAuthentication().AddJwtBearer(cfg => {
        cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters() {
          // ValidIssuer = Configuration[""],
          // ValidateIssuer = true,
          // ValidAudience = Configuration[""],
          // ValidateAudience = true,
          // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[""])),
          // RequireSignedTokens = true,
          // RequireExpirationTime = true,
          // ValidateLifetime = true
        };
      });
      /// API Services
      // Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto, int
      services.AddScoped<IActionsService, ActionsService>();
      services.AddScoped<IHasIdService<ActionEquipment, int, int>, AuthService<ActionEquipment, int, int>>();
      services.AddScoped<IHasIdService<ActionMember, int, int>, AuthService<ActionMember, int, int>>();
      services.AddScoped<IHasIdService<Equipment, int>, AuthService<Equipment, int>>();
      services.AddScoped<IHasIdService<Member, int>, AuthService<Member, int>>();
      /// API Controllers
      services.AddControllers()
        .AddNewtonsoftJson(s => {
          s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        })
        .AddControllersAsServices();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
