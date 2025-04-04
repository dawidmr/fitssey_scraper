using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrapper;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IFrontOfficerovider, FrontOfficeroviderProvider>();
builder.Services.AddScoped<IScheduleProvider, ScheduleProvider>();
builder.Services.AddScoped<Runner>();

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
var runner = serviceScope.ServiceProvider.GetRequiredService<Runner>();
await runner.Run();

await host.RunAsync();