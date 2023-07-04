using MediatR;
using Microsoft.Extensions.Logging;

namespace VolleyballInfo.DataGathererService.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        
        _logger.LogInformation("Started processing request {RequestName}", requestName);
        var result = await next();
        _logger.LogInformation("Finished processing request {RequestName}", requestName);
        
        return result;
    }
}