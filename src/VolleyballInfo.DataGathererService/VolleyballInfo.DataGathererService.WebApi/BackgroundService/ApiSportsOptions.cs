namespace VolleyballInfo.DataGathererService.WebApi.BackgroundService;

public class BackgroundServiceOptions
{
    public const string SectionName = "BackgroundService";
    
    public int TimeBeforeNextExecutionInMinutes { get; init; }
}