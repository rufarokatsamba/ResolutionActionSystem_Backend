using MediatR;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.Responses;

namespace ResolutionActionSystem.Application.Features.Meetings.Requests.Commands
{
    public class CreateMeetingCommand: IRequest<BaseCommandResponse>
    {
        public CreateMeetingDto CreateMeetingDto { get; set; }
    }
}
