namespace VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherNationsLeagueInformation;

public record StandingsDto(
    int TeamId,
    string TeamName,
    int LeaguePosition,
    int LeaguePoints,
    string PointsForm,
    int PlayedGamesCount,
    int WinGamesCount,
    int LooseGamesCount,
    int WinSetsCount,
    int LooseSetsCount
);