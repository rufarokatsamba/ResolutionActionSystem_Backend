using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.MeetingTypes.Handlers.Queries
{
    public class GetMeetingTypeDetailRequestHandler : IRequestHandler<GetMeetingTypeDetailRequest, MeetingTypeDto>
    {
        private readonly IMeetingTypeRepository _meetingTypeRepository;
        private readonly IMapper _mapper;
        public GetMeetingTypeDetailRequestHandler(IMeetingTypeRepository meetingTypeRepository, IMapper mapper)
        {
            _meetingTypeRepository = meetingTypeRepository;
            _mapper = mapper; //converts our db domain objects to dtos
        }

        public async Task<MeetingTypeDto> Handle(GetMeetingTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var meetingType = await _meetingTypeRepository.GetAsync(request.Id);
            return _mapper.Map<MeetingTypeDto>(meetingType);
        }
    }
}
