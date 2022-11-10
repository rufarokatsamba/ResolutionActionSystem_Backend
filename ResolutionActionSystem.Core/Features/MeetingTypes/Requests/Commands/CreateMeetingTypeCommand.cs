using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Application.Responses;

namespace ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Commands
{
    public class CreateMeetingTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateMeetingTypeDto CreateMeetingTypeDto { get; set; }
    }
}
