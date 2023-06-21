using MediatR;

namespace VolleyballInfo.DataGathererService.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}