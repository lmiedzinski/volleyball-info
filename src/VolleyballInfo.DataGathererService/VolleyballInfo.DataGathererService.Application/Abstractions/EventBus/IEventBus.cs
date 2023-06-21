namespace VolleyballInfo.DataGathererService.Application.Abstractions.EventBus;

public interface IEventBus
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken = default)
        where T : class;
}