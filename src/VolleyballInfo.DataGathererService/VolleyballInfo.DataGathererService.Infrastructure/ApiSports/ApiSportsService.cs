using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VolleyballInfo.DataGathererService.Application.Abstractions.ApiSports;
using VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherNationsLeagueInformation;

namespace VolleyballInfo.DataGathererService.Infrastructure.ApiSports;

public class ApiSportsService : IApiSportsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiSportsService> _logger;

    public ApiSportsService(HttpClient httpClient, ILogger<ApiSportsService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<StandingsDto>> GetLeagueStandingsForSeasonAsync(
        int leagueId,
        string season,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetAsync(
                $"/standings?league={leagueId}&season={season}",
                cancellationToken);
            
            response.EnsureSuccessStatusCode();
            
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            var standingsResponse = JsonConvert.DeserializeObject<StandingsResponse>(responseBody);
            
            return standingsResponse?.Responses.FirstOrDefault()?.Select(x => x.ToApplication())
                   ?? new List<StandingsDto>();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting standings for league {League} and season {Season}", leagueId, season);
            return new List<StandingsDto>();
        }
    }
}