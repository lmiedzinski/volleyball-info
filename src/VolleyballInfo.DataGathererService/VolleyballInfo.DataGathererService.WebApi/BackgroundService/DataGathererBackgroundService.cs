using MediatR;
using Microsoft.Extensions.Options;
using VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherNationsLeagueInformation;

namespace VolleyballInfo.DataGathererService.WebApi.BackgroundService;

public class DataGathererBackgroundService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<DataGathererBackgroundService> _logger;
    private readonly IOptions<BackgroundServiceOptions> _options;

    public DataGathererBackgroundService(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<DataGathererBackgroundService> logger,
        IOptions<BackgroundServiceOptions> options)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var gatherNationsLeagueInformationCommand = new GatherNationsLeagueInformationCommand();
                await mediator.Send(gatherNationsLeagueInformationCommand, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request failed during processing");
            }
            
            await Task.Delay(TimeSpan.FromMinutes(_options.Value.TimeBeforeNextExecutionInMinutes), stoppingToken);
        }
    }
}