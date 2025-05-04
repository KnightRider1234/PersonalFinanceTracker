using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PersonalFinanceTracker.Client;
using PersonalFinanceTracker.Client.Interfaces;
using PersonalFinanceTracker.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7020") });
builder.Services.AddScoped(typeof(IHttpDataService<>), typeof(HttpDataService<>));
builder.Services.AddMudServices();

await builder.Build().RunAsync();