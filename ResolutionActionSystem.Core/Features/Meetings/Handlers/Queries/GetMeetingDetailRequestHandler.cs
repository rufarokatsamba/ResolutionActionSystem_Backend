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
        private readonly IMeetingTypeRepository _meetingTypeRepository;
        public GetMeetingDetailRequestHandler(IMeetingRepository meetingRepository, IMapper mapper, IMeetingTypeRepository meetingTypeRepository)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _meetingTypeRepository = meetingTypeRepository; 
        }
        public async Task<MeetingDto> Handle(GetMeetingDetailRequest request, CancellationToken cancellationToken)
        {
            var meeting = _mapper.Map<MeetingDto>(await _meetingRepository.GetMeetingWithDetail(request.Id));
            //meeting.MeetingType = await _meetingTypeRepository.GetAsync(meeting.MeetingTypeId);
            return meeting;
        }
    }
}
