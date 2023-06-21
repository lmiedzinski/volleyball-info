using MediatR;

namespace VolleyballInfo.DataGathererService.Application.Abstractions.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}