using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingItem;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Requests.Queries
{
    public class GetMeetingItemDetailRequest: IRequest<MeetingItemDto>
    {
        public int Id { get; set; }
    }
}
