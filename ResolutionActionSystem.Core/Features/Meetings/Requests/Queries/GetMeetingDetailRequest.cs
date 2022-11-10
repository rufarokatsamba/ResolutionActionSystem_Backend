using MediatR;
using ResolutionActionSystem.Application.DTOs.Meeting;

namespace ResolutionActionSystem.Application.Features.Meetings.Requests.Queries
{
    public class GetMeetingDetailRequest: IRequest<MeetingDto>
    {
        public int Id { get; set; }
    }
}
