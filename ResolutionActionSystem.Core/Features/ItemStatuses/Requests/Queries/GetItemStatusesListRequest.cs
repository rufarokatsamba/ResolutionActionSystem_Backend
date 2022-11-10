using MediatR;
using ResolutionActionSystem.Application.DTOs.ItemStatus;

namespace ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Queries
{
    public class GetItemStatusesListRequest : IRequest<List<ItemStatusListDto>>
    {
    }
}

