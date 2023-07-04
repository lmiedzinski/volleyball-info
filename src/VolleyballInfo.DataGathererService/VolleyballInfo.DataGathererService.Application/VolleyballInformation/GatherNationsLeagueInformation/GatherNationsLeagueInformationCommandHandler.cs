using VolleyballInfo.DataGathererService.Application.Abstractions.ApiSports;
using VolleyballInfo.DataGathererService.Application.Abstractions.Messaging;

namespace VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherVolleyballInformation;

public class GatherVolleyballInformationCommandHandler : ICommandHandler<GatherNationsLeagueInformationCommand>
{
    private readonly IApiSportsService _apiSportsService;

    public GatherVolleyballInformationCommandHandler(IApiSportsService apiSportsService)
    {
        _apiSportsService = apiSportsService;
    }

    public async Task Handle(GatherNationsLeagueInformationCommand request, CancellationToken cancellationToken)
    {
        var currentStandings = await _apiSportsService.GetLeagueStandingsForSeasonAsync();
    }
}