using VolleyballInfo.Common.Constants;
using VolleyballInfo.Common.EventBusMessages;
using VolleyballInfo.DataGathererService.Application.Abstractions.ApiSports;
using VolleyballInfo.DataGathererService.Application.Abstractions.EventBus;
using VolleyballInfo.DataGathererService.Application.Abstractions.Messaging;

namespace VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherNationsLeagueInformation;

public class GatherNationsLeagueInformationCommandHandler : ICommandHandler<GatherNationsLeagueInformationCommand>
{
    private readonly IApiSportsService _apiSportsService;
    private readonly IEventBus _eventBus;

    public GatherNationsLeagueInformationCommandHandler(IApiSportsService apiSportsService, IEventBus eventBus)
    {
        _apiSportsService = apiSportsService;
        _eventBus = eventBus;
    }

    public async Task Handle(GatherNationsLeagueInformationCommand request, CancellationToken cancellationToken)
    {
        var currentSeason = DateTime.UtcNow.ToString("yyyy");
        
        var currentStandings = await _apiSportsService.GetLeagueStandingsForSeasonAsync(
            LeagueIds.NationsLeagueId,
            currentSeason,
            cancellationToken);
        
        var currentStandingsList = currentStandings.ToList();
        if(!currentStandingsList.Any()) return;

        var newDataGatheredMessage = new NewDataGatheredMessage(
            LeagueIds.NationsLeagueId,
            currentSeason,
            DateTime.UtcNow,
            currentStandingsList.Select(x => new NewDataGatheredMessageItem(
                x.TeamId,
                x.TeamName,
                x.LeaguePosition,
                x.LeaguePoints,
                x.PointsForm,
                x.PlayedGamesCount,
                x.WinGamesCount,
                x.LooseGamesCount,
                x.WinSetsCount,
                x.LooseSetsCount)));

        await _eventBus.PublishAsync(newDataGatheredMessage, cancellationToken);
    }
}