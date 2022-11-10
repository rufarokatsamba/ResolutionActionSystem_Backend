using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.Features.MeetingItems.Requests.Commands;

namespace ResolutionActionSystem.Application.Features.MeetingItems.Handlers.Commands
{
    public class UpdateMeetingItemCommandHandler : IRequestHandler<UpdateMeetingItemCommand, Unit>
    {
        private readonly IMeetingItemRepository _meetingItemReposistory;
        private readonly IMapper _mapper;

        public UpdateMeetingItemCommandHandler(IMeetingItemRepository meetingItemReposistory, IMapper mapper)
        {
            _meetingItemReposistory = meetingItemReposistory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMeetingItemCommand request, CancellationToken cancellationToken)
        {
            var meetingItem = await _meetingItemReposistory.GetAsync(request.UpdateMeetingItemDto.Id);

            if (request.UpdateMeetingItemDto != null)
            {
                _mapper.Map(request.UpdateMeetingItemDto, meetingItem);
                await _meetingItemReposistory.UpdateAsync(meetingItem);
            }
            return Unit.Value;
        }
    }
}
