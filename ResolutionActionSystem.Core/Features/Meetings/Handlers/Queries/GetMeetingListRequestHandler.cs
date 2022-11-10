using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.Features.Meetings.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.Meetings.Handlers.Queries
{
    public class GetMeetingListRequestHandler : IRequestHandler<GetMeetingListRequest, List<MeetingDto>>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
        public GetMeetingListRequestHandler(IMeetingRepository meetingRepository,IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper; //converts our db domain objects to dtos
        }
        public async Task<List<MeetingDto>> Handle(GetMeetingListRequest request, CancellationToken cancellationToken)
        {
            var meetings = await _meetingRepository.GetMeetingsWithDetail();
            return _mapper.Map<List<MeetingDto>>(meetings);
        }
    }
}
