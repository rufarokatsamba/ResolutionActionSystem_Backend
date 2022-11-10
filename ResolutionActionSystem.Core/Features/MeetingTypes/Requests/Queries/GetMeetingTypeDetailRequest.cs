using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingType;

namespace ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Queries
{
    public class GetMeetingTypeDetailRequest: IRequest<MeetingTypeDto>
    {
        public int Id { get; set; } 
    }
}
