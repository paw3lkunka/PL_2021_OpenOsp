using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Fluxor;

namespace OpenOsp.Client {

  public class Program {

    public static async Task Main(string[] args) {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");
      /// Services
      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddFluxor(cfg => {
        cfg.ScanAssemblies(typeof(Program).Assembly);
        cfg.UseReduxDevTools();
      });
      /// Build
      await builder.Build().RunAsync();
    }

  }

}
