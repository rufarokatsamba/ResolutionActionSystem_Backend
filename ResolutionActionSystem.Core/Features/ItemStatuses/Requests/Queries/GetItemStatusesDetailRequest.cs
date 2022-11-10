using MediatR;
using ResolutionActionSystem.Application.DTOs.ItemStatus;

namespace ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Queries
{
    public class GetItemStatusesDetailRequest: IRequest<ItemStatusDto>
    {
        public int Id { get; set; }
    }
}
