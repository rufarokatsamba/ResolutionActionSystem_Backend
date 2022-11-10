
using MediatR;
using ResolutionActionSystem.Application.DTOs.Meeting;

namespace ResolutionActionSystem.Application.Features.Meetings.Requests.Queries
{
    public class GetMeetingListRequest : IRequest<List<MeetingDto>>
    {
    }
}

