using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingItem;
using ResolutionActionSystem.Application.Responses;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Requests.Commands
{
    public class CreateMeetingItemCommand: IRequest<BaseCommandResponse>
    {
        public CreateMeetingItemDto CreateMeetingItemDto { get; set; }
    }
}
