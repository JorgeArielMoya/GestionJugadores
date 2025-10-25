using GestionJugadores.BlazorWasm;
using GestionJugadores.BlazorWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/") });

builder.Services.AddScoped<IPartidasApiService, PartidasApiService>();
builder.Services.AddScoped<IMovimientoApiService, MovimientosApiService>();

await builder.Build().RunAsync();
