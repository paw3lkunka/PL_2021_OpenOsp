using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;
using Microsoft.AspNetCore.Identity;

namespace OpenOsp.WebApi {
  public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddCors();
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      services.AddControllers().AddNewtonsoftJson();

      services.AddDbContext<AppDbContext>(options => {
        options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"), builder => {
          builder.MigrationsAssembly("OpenOsp.Data");
          builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        })
        .EnableSensitiveDataLogging();

        options.UseMySql(Configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version()), builder => {
          builder.MigrationsAssembly("OpenOsp.Data");
          builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        })
        .EnableSensitiveDataLogging();
      });

      services.AddIdentityCore<User>(cfg => {
        cfg.User.RequireUniqueEmail = true;
        cfg.Password.RequireDigit = false;
        cfg.Password.RequireLowercase = false;
        cfg.Password.RequireUppercase = false;
        cfg.Password.RequireNonAlphanumeric = false;
        cfg.Password.RequiredLength = 12;
        cfg.SignIn.RequireConfirmedEmail = true;
      })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

      // services.Configure<Configuration>(Configuration.GetSection(""));

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

      // services.AddScoped<IService, Service>();
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
