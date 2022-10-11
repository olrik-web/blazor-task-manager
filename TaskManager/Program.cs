using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// If the environment is Development, use the Development API URL (localhost) otherwise use the Production API URL (Azure). This is done to avoid CORS issues. 
if (builder.HostEnvironment.IsDevelopment())
{
    // If you want to use a different URI for the API, set the BaseAddress property.
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7209") });
}
else
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });
}

// Add the Radzen services to the Dependency Injection container. This is required to use the Radzen components. 
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
// Add the Blazored Modal services to the Dependency Injection container. This is required to use the Blazored Modal components.
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
