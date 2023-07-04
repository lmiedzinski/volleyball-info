using Newtonsoft.Json;

namespace VolleyballInfo.DataGathererService.Infrastructure.ApiSports;

public record StandingsResponse(
    [property: JsonProperty("get")] string MethodName,
    [property: JsonProperty("results")] int ResultsCount,
    [property: JsonProperty("response")] IEnumerable<IEnumerable<StandingsResponseItem>> Responses);

public record StandingsResponseItem(
    [property: JsonProperty("position")] int Position,
    [property: JsonProperty("team")] StandingsResponseItemTeam Team,
    [property: JsonProperty("games")] StandingsResponseItemGames Games,
    [property: JsonProperty("goals")] StandingsResponseItemSetPoints SetPoints,
    [property: JsonProperty("points")] int Points,
    [property: JsonProperty("form")] string Form);

public record StandingsResponseItemTeam(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name);

public record StandingsResponseItemGames(
    [property: JsonProperty("played")] int Played,
    [property: JsonProperty("win")] StandingsResponseItemGamesStats Win,
    [property: JsonProperty("lose")] StandingsResponseItemGamesStats Lose);

public record StandingsResponseItemGamesStats(
    [property: JsonProperty("total")] int Total,
    [property: JsonProperty("percentage")] string Percentage);
    
public record StandingsResponseItemSetPoints(
    [property: JsonProperty("for")] int For,
    [property: JsonProperty("against")] int Against);