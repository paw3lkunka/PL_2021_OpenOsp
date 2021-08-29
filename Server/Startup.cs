using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json.Serialization;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Controllers;
using OpenOsp.Server.Api.Services;
using OpenOsp.Server.Data.Contexts;
using OpenOsp.Server.Settings;

namespace OpenOsp.Server {

  public class Startup {

    public Startup(
      IConfiguration configuration,
      IWebHostEnvironment env
    ) {
      Configuration = configuration;
      _env = env;
    }

    public IConfiguration Configuration { get; }

    private readonly IWebHostEnvironment _env;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      /// Load configuration files
      services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
      services.Configure<EmailSettings>(Configuration.GetSection("Email"));
      /// Basic server configuration
      services.AddCors();
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Latest);
      /// Database Context
      services.AddDbContext<AppDbContext>(options => {
        options.UseNpgsql(
          Configuration.GetConnectionString("PostgreSql"),
          builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
        )
        .EnableSensitiveDataLogging(false);
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
      })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders()
        .AddUserManager<UserManager<User>>()
        .AddSignInManager<SignInManager<User>>();
      /// Authentication with JWT
      services.AddAuthentication()
        .AddJwtBearer(cfg => {
          cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters() {
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidateIssuer = true,
            ValidAudience = Configuration["Jwt:Audience"],
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ValidateLifetime = true
          };
        });
      /// API Services
      services.AddScoped<IUsersService<User, int>, UsersService<User, int>>();
      services.AddScoped<IUserClaimsService<int>, UserClaimsService<int>>();
      services.AddScoped<IActionsService, ActionsService>();
      services.AddScoped<IHasIdService<ActionEquipment, int, int>, AuthService<ActionEquipment, int, int>>();
      services.AddScoped<IHasIdService<ActionMember, int, int>, AuthService<ActionMember, int, int>>();
      services.AddScoped<IHasIdService<Equipment, int>, AuthService<Equipment, int>>();
      services.AddScoped<IHasIdService<Member, int>, AuthService<Member, int>>();
      services.AddScoped<IEmailsService, EmailsService>();
      /// DTO Mappers
      services.AddScoped<IDtoMapper<Model.Models.Action, ActionCreateDto, ActionReadDto, ActionUpdateDto>, ActionDtoMapper>();
      services.AddScoped<IDtoMapper<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto>, ActionEquipmentDtoMapper>();
      services.AddScoped<IDtoMapper<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto>, ActionMemberDtoMapper>();
      services.AddScoped<IDtoMapper<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto>, EquipmentDtoMapper>();
      services.AddScoped<IDtoMapper<Member, MemberCreateDto, MemberReadDto, MemberUpdateDto>, MemberDtoMapper>();
      /// API Controllers
      services.AddControllers()
        .AddNewtonsoftJson(s => {
          s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
      services.AddScoped<ActionEquipmentController>();
      services.AddScoped<ActionMembersController>();
      /// HTTPS Redirection
      services.AddHttpsRedirection(options => {
        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
        options.HttpsPort = _env.IsDevelopment() ? 5001 : 443;
      });
      /// Blazor WebAssembly
      services.AddRazorPages();
      /// Swagger
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "OpenOsp.Server", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app) {
      if (_env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenOsp.Server v1"));
      }
      else {
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseBlazorFrameworkFiles();
      app.UseStaticFiles();
      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
        endpoints.MapFallbackToFile("{*path:nonfile}", "index.html");
      });
    }

  }

}
