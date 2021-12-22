using System;
using System.Net;
using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json.Serialization;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Server.Api.Controllers;
using OpenOsp.Server.Api.Repositories;
using OpenOsp.Server.Api.Services;
using OpenOsp.Server.Data.Contexts;
using OpenOsp.Server.Settings;

using OspM = OpenOsp.Model.Models;

namespace OpenOsp.Server; 

public class Startup {
  private readonly IWebHostEnvironment _env;

  public Startup(
    IConfiguration configuration,
    IWebHostEnvironment env) {
    Configuration = configuration;
    _env = env;
  }

  public IConfiguration Configuration { get; }

  /// This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services) {
    /// Load configuration files
    services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
    services.Configure<EmailSettings>(Configuration.GetSection("Email"));
    /// Basic server configuration
    services.AddCors();
    services.AddMvc();
    /// Database Context
    services.AddDbContext<AppDbContext>(options => {
      options.UseNpgsql(
          Configuration.GetConnectionString("PostgreSql"),
          builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
        )
        .EnableSensitiveDataLogging(false);
    });
    /// Identity users
    services.AddIdentityCore<OspM.User>(cfg => {
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
      .AddUserManager<UserManager<OspM.User>>()
      .AddSignInManager<SignInManager<OspM.User>>();
    /// Authentication with JWT
    services.AddAuthentication()
      .AddJwtBearer(cfg => {
        cfg.TokenValidationParameters = new TokenValidationParameters {
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
    /// API Repositories
    /// HasIdRepository as IHasIdRepository
    services.AddScoped<IHasIdRepository<OspM.Action, int>, HasIdRepository<OspM.Action, int>>();
    services
      .AddScoped<IHasIdRepository<OspM.ActionEquipment, int, int>, HasIdRepository<OspM.ActionEquipment, int, int>>();
    services.AddScoped<IHasIdRepository<OspM.ActionMember, int, int>, HasIdRepository<OspM.ActionMember, int, int>>();
    services.AddScoped<IHasIdRepository<OspM.Equipment, int>, HasIdRepository<OspM.Equipment, int>>();
    services.AddScoped<IHasIdRepository<OspM.Member, int>, HasIdRepository<OspM.Member, int>>();
    /// UnauthorizedRepository as IHasIdRepository
    // services.AddScoped<IHasIdRepository<OspM.Action, int>, UnauthorizedRepository<OspM.Action, int>>();
    // services.AddScoped<IHasIdRepository<OspM.ActionEquipment, int, int>, UnauthorizedRepository<OspM.ActionEquipment, int, int>>();
    // services.AddScoped<IHasIdRepository<OspM.ActionMember, int, int>, UnauthorizedRepository<OspM.ActionMember, int, int>>();
    // services.AddScoped<IHasIdRepository<OspM.Equipment, int>, UnauthorizedRepository<OspM.Equipment, int>>();
    // services.AddScoped<IHasIdRepository<OspM.Member, int>, UnauthorizedRepository<OspM.Member, int>>();
    /// API Services
    /// HasIdService as IHasIdService
    services.AddScoped<IHasIdService<OspM.Action, int>, HasIdService<OspM.Action, int>>();
    services.AddScoped<IHasIdService<OspM.ActionEquipment, int, int>, HasIdService<OspM.ActionEquipment, int, int>>();
    services.AddScoped<IHasIdService<OspM.ActionMember, int, int>, HasIdService<OspM.ActionMember, int, int>>();
    services.AddScoped<IHasIdService<OspM.Equipment, int>, HasIdService<OspM.Equipment, int>>();
    services.AddScoped<IHasIdService<OspM.Member, int>, HasIdService<OspM.Member, int>>();
    /// AuhorizedService as IHasIdService
    // services.AddScoped<IHasIdService<OspM.Action, int>, AuthorizedService<OspM.Action, int, int>>();
    // services.AddScoped<IHasIdService<OspM.Equipment, int>, AuthorizedService<OspM.Equipment, int, int>>();
    // services.AddScoped<IHasIdService<OspM.Member, int>, AuthorizedService<OspM.Member, int, int>>();
    /// EntitiesAuthService as IEntitiesAuthService
    // services.AddScoped<IEntitiesAuthService<OspM.Action>, EntitiesAuthService<OspM.Action, int>>();
    // services.AddScoped<IEntitiesAuthService<OspM.Equipment>, EntitiesAuthService<OspM.Equipment, int>>();
    // services.AddScoped<IEntitiesAuthService<OspM.Member>, EntitiesAuthService<OspM.Member, int>>();
    /// Other services
    services.AddScoped<IEmailsService, EmailsService>();
    services.AddScoped<IUserService<OspM.User, int>, UserService<OspM.User, int>>();
    services.AddScoped<IUserClaimsService<int>, UserClaimsService<int>>();
    /// DTO Mappers
    services.AddScoped<IDtoMapper<OspM.Action, ActionCreateDto, ActionReadDto, ActionUpdateDto>, ActionDtoMapper>();
    services
      .AddScoped<IDtoMapper<OspM.ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto,
        ActionEquipmentUpdateDto>, ActionEquipmentDtoMapper>();
    services
      .AddScoped<IDtoMapper<OspM.ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto>,
        ActionMemberDtoMapper>();
    services
      .AddScoped<IDtoMapper<OspM.Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto>,
        EquipmentDtoMapper>();
    services.AddScoped<IDtoMapper<OspM.Member, MemberCreateDto, MemberReadDto, MemberUpdateDto>, MemberDtoMapper>();
    services.AddScoped<IUserDtoMapper, UserDtoMapper>();
    /// API Controllers
    services.AddControllers()
      .AddNewtonsoftJson(s => {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      });
    services.AddScoped<ActionEquipmentController>();
    services.AddScoped<ActionMembersController>();
    /// Blazor WebAssembly
    services.AddRazorPages();
    /// HTTPS Redirection
    services.AddHttpsRedirection(options => {
      options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
      options.HttpsPort = _env.IsDevelopment() ? 5001 : 443;
    });
    /// Development-only and Production-only services
    if (_env.IsDevelopment()) {
      /// Swagger
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo {Title = "OpenOsp.Server", Version = "v1"});
      });
    }
    else {
      /// HSTS (HTTP Secure Transport Security)
      services.AddHsts(options => {
        options.MaxAge = new TimeSpan(30, 0, 0, 0);
        options.IncludeSubDomains = true;
        options.Preload = true;
      });
    }
  }

  /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app) {
    app.UseHttpsRedirection();
    if (_env.IsDevelopment()) {
      app.UseDeveloperExceptionPage();
      app.UseWebAssemblyDebugging();
      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenOsp.Server v1"));
    }
    else {
      app.UseHsts();
    }

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