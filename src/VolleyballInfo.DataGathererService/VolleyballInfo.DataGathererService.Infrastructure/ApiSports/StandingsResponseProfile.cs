using VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherNationsLeagueInformation;

namespace VolleyballInfo.DataGathererService.Infrastructure.ApiSports;

public static class StandingsResponseProfile
{
    public static StandingsDto ToApplication(this StandingsResponseItem standingsResponseItem)
        => new(
            standingsResponseItem.Team.Id,
            standingsResponseItem.Team.Name,
            standingsResponseItem.Points,
            standingsResponseItem.Position,
            standingsResponseItem.Form,
            standingsResponseItem.Games.Played,
            standingsResponseItem.Games.Win.Total,
            standingsResponseItem.Games.Lose.Total,
            standingsResponseItem.SetPoints.For,
            standingsResponseItem.SetPoints.Against);
}