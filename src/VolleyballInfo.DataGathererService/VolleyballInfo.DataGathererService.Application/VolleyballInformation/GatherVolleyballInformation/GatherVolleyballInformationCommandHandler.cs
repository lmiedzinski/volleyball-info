using VolleyballInfo.DataGathererService.Application.Abstractions.Messaging;

namespace VolleyballInfo.DataGathererService.Application.VolleyballInformation.GatherVolleyballInformation;

public class GatherVolleyballInformationCommandHandler : ICommandHandler<GatherVolleyballInformationCommand>
{
    public async Task Handle(GatherVolleyballInformationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}