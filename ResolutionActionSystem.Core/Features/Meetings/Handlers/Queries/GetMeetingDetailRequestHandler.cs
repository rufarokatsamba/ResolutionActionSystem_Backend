using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.Features.Meetings.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.Meetings.Handlers.Queries
{
    public class GetMeetingDetailRequestHandler : IRequestHandler<GetMeetingDetailRequest, MeetingDto>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
       public GetMeetingDetailRequestHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }
        public async Task<MeetingDto> Handle(GetMeetingDetailRequest request, CancellationToken cancellationToken)
        {
            var meeting = await _meetingRepository.GetMeetingWithDetail(request.Id);
            return _mapper.Map<MeetingDto>(meeting);
        }
    }
}
