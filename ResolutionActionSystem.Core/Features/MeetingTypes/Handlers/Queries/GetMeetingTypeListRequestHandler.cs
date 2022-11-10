using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.MeetingTypes.Handlers.Queries
{
    public class GetMeetingTypeListRequestHandler : IRequestHandler<GetMeetingTypeListRequest, List<MeetingTypeDto>>
    {
        private readonly IMeetingTypeRepository _meetingTypeRepository;
        private readonly IMapper _mapper;
        public GetMeetingTypeListRequestHandler(IMeetingTypeRepository meetingTypeRepository , IMapper mapper)
        {
            _meetingTypeRepository = meetingTypeRepository;
            _mapper = mapper; //converts our db domain objects to dtos
        }
        public async Task<List<MeetingTypeDto>> Handle(GetMeetingTypeListRequest request, CancellationToken cancellationToken)
        {
            var meetingTypes = await _meetingTypeRepository.GetAllAsync();
            return  _mapper.Map<List<MeetingTypeDto>>(meetingTypes);  
        }
    }
}
