using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingItem;
using ResolutionActionSystem.Application.Features.MeetingItems.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Handlers.Queries
{
    public class GetMeetingItemDetailRequestHandler : IRequestHandler<GetMeetingItemDetailRequest, MeetingItemDto>
    {
        private readonly IMeetingItemRepository _meetingItemReposistory;
        private readonly IMapper _mapper;

        public GetMeetingItemDetailRequestHandler(IMeetingItemRepository meetingItemReposistory, IMapper mapper)
        {
            _meetingItemReposistory = meetingItemReposistory;
            _mapper = mapper;
        }

        public async Task<MeetingItemDto> Handle(GetMeetingItemDetailRequest request, CancellationToken cancellationToken)
        {
            var meetingItem = await _meetingItemReposistory.GetMeetingItemWithDetail(request.Id);
            return _mapper.Map<MeetingItemDto>(meetingItem);
        }
    }
}
