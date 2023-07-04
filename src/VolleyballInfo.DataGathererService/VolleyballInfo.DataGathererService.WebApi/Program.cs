using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using VolleyballInfo.DataGathererService.Application;
using VolleyballInfo.DataGathererService.Infrastructure;
using VolleyballInfo.DataGathererService.WebApp.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddHealthChecks();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddHostedService<DataGathererBackgroundService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();