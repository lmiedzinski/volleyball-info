using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VolleyballInfo.Common.EventBusMessages;
using VolleyballInfo.DataGathererService.Application.Abstractions.ApiSports;
using VolleyballInfo.DataGathererService.Application.Abstractions.EventBus;
using VolleyballInfo.DataGathererService.Infrastructure.ApiSports;
using VolleyballInfo.DataGathererService.Infrastructure.MessageBroker;

namespace VolleyballInfo.DataGathererService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddOptions<ApiSportsOptions>()
            .Bind(configuration.GetSection(ApiSportsOptions.SectionName));
        services
            .AddOptions<MessageBrokerOptions>()
            .Bind(configuration.GetSection(MessageBrokerOptions.SectionName));

        services.AddHttpClient<IApiSportsService, ApiSportsService>((serviceProvider, client) =>
        {
            var apiSportsOptions = serviceProvider.GetRequiredService<IOptions<ApiSportsOptions>>().Value;

            client.BaseAddress = new Uri(apiSportsOptions.BaseUrl ?? string.Empty);
            client.DefaultRequestHeaders.Add(
                apiSportsOptions.ApiKeyName ?? string.Empty,
                apiSportsOptions.ApiKeyValue);
        });

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
    
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                var options = context.GetRequiredService<IOptions<MessageBrokerOptions>>().Value;

                configurator.Host(new Uri(options.Host), h =>
                {
                    h.Username(options.Username);
                    h.Password(options.Password);
                });

                configurator.Publish<NewDataGatheredMessage>();
        
                // EndpointConvention.Map<NewDataGatheredMessage>(new Uri(options.Queue));
            });
        });
        
        services.AddTransient<IEventBus, EventBus>();
    }
}