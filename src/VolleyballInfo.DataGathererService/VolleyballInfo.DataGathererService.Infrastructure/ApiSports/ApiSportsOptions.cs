namespace VolleyballInfo.DataGathererService.Infrastructure.ApiSports;

public class ApiSportsOptions
{
    public const string SectionName = "ApiSports";
    
    public string? BaseUrl { get; init; }
    public string? ApiKeyName { get; init; }
    public string? ApiKeyValue { get; init; }
}