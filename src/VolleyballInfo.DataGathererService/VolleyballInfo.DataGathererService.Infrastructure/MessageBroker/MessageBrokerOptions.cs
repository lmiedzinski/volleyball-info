namespace VolleyballInfo.DataGathererService.Infrastructure.MessageBroker;

public sealed class MessageBrokerOptions
{
    public string Host { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}