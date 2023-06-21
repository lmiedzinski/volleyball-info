using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Serilog;
using VolleyballInfo.DataGathererService.Application;
using VolleyballInfo.DataGathererService.Application.Abstractions.EventBus;
using VolleyballInfo.DataGathererService.Infrastructure.MessageBroker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<MessageBrokerOptions>(
    builder.Configuration.GetSection("MessageBroker"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<MessageBrokerOptions>>().Value);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        var options = context.GetRequiredService<MessageBrokerOptions>();

        configurator.Host(new Uri(options.Host), h =>
        {
            h.Username(options.Username);
            h.Password(options.Password);
        });

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddTransient<IEventBus, EventBus>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(ApplicationAssembly.Instance);
});

builder.Services
    .AddHealthChecks();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();