using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingItem;
using ResolutionActionSystem.Application.Features.MeetingItems.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Handlers.Queries
{
    public class GetMeetingItemListRequestHandler : IRequestHandler<GetMeetingItemListRequest, List<MeetingItemDto>>
    {
        private readonly IMeetingItemRepository _meetingItemReposistory;
        private readonly IMapper _mapper;
        public GetMeetingItemListRequestHandler(IMeetingItemRepository meetingItemReposistory, IMapper mapper)
        {
            _meetingItemReposistory = meetingItemReposistory;
            _mapper = mapper;
        }
        public async Task<List<MeetingItemDto>> Handle(GetMeetingItemListRequest request, CancellationToken cancellationToken)
        {
            var meetingItems = await _meetingItemReposistory.GetMeetingItemsWithDetail();
            return _mapper.Map<List<MeetingItemDto>>(meetingItems);
        }
    }
}
