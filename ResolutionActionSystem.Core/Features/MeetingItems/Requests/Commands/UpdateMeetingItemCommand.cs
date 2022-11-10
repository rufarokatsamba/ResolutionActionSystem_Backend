using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingItem;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Requests.Commands
{
    public class UpdateMeetingItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateMeetingItemDto? UpdateMeetingItemDto { get; set; }
    }
}
