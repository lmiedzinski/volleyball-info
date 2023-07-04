namespace VolleyballInfo.Common.EventBusMessages;

public record NewDataGatheredMessage(
    int LeagueId,
    string Season,
    DateTime GatheredAt,
    IEnumerable<NewDataGatheredMessageItem> Items);

public record NewDataGatheredMessageItem(
    int TeamId,
    string TeamName,
    int LeaguePosition,
    int LeaguePoints,
    string PointsForm,
    int PlayedGamesCount,
    int WinGamesCount,
    int LooseGamesCount,
    int WinSetsCount,
    int LooseSetsCount);