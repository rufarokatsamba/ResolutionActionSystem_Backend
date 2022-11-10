using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingItem;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Requests.Queries
{
    public class GetMeetingItemListRequest: IRequest<List<MeetingItemDto>>
    {
    }
}
