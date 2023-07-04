using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VolleyballInfo.DataGathererService.Application.Behaviors;

namespace VolleyballInfo.DataGathererService.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(ApplicationAssembly.Instance);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        });
    }
}