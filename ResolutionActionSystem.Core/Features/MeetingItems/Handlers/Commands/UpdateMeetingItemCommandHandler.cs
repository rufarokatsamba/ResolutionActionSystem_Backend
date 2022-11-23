using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingItem.Validators;
using ResolutionActionSystem.Application.Exceptions;
using ResolutionActionSystem.Application.Features.MeetingItems.Requests.Commands;
using ResolutionActionSystem.Application.Responses;
using ResolutionActionSystem.Domain.Entities;

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
            var responses = new BaseCommandResponse();
            var validator = new UpdateMeetingItemDtoValidator(_meetingItemReposistory);
            var validationResult = await validator.ValidateAsync(request.UpdateMeetingItemDto);

            if (validationResult.IsValid == false)
            {
                responses.Success = false;
                responses.Message = "Update failed";
                responses.Error = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }
            else if (request.UpdateMeetingItemDto != null)
            {
                var meetingItem = await _meetingItemReposistory.GetAsync(request.UpdateMeetingItemDto.Id);
           
                _mapper.Map(request.UpdateMeetingItemDto, meetingItem);
                await _meetingItemReposistory.UpdateAsync(meetingItem);
            }
            return Unit.Value;
        }
    }
}
