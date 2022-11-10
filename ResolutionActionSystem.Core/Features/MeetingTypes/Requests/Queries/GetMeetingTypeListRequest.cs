using MediatR;
using ResolutionActionSystem.Application.DTOs.MeetingType;

namespace ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Queries
{
    public class GetMeetingTypeListRequest : IRequest<List<MeetingTypeDto>>
    {
    }
}
