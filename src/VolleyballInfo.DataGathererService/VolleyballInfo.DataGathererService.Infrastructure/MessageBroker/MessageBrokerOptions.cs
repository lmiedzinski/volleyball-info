namespace VolleyballInfo.DataGathererService.Infrastructure.MessageBroker;

public sealed class MessageBrokerOptions
{
    public const string SectionName = "MessageBroker";
    
    public string Host { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Queue { get; set; } = string.Empty;
}