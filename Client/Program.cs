using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace OpenOsp.Client {
  public class Program {
    public static async Task Main(string[] args) {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");
      /// HttpClient
      builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
      /// Blazored.LocalStorage
      builder.Services.AddBlazoredLocalStorage(config => {
        config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        config.JsonSerializerOptions.IgnoreNullValues = true;
        config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
        config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
        config.JsonSerializerOptions.WriteIndented = false;
      });
      /// Blazored.FormExtensions
      builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
      builder.Services.AddSingleton(typeof(IStringLocalizer), typeof(StringLocalizer<Locale.Locale>));
      /// Build
      await builder.Build().RunAsync();
    }
  }
}