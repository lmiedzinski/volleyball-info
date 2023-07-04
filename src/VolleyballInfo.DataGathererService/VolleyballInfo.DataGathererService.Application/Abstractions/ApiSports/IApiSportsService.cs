using VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherNationsLeagueInformation;

namespace VolleyballInfo.DataGathererService.Application.Abstractions.ApiSports;

public interface IApiSportsService
{
    Task<IEnumerable<StandingsDto>> GetLeagueStandingsForSeasonAsync(
        int leagueId,
        string season,
        CancellationToken cancellationToken);
}