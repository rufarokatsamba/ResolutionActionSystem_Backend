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
    public class CreateMeetingItemRequestHandler : IRequestHandler<CreateMeetingItemCommand, BaseCommandResponse>
    {
        private readonly IMeetingItemRepository _meetingItemReposistory;
        private readonly IMapper _mapper;

        public CreateMeetingItemRequestHandler(IMeetingItemRepository meetingItemReposistory, IMapper mapper)
        {
            _meetingItemReposistory = meetingItemReposistory;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMeetingItemCommand request, CancellationToken cancellationToken)
        {
            var responses = new BaseCommandResponse();
            var validator = new CreateMeetingItemDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateMeetingItemDto);


            var meeting = _mapper.Map<MeetingItem>(request.CreateMeetingItemDto);

            meeting = await _meetingItemReposistory.Add(meeting);
            if (validationResult.IsValid == false)
            {
                responses.Success = false;
                responses.Message = "Creation failed";
                responses.Error = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }
            else
            {
                responses.Success = true;
                responses.Message = "Creation successful";
                responses.Name = request.CreateMeetingItemDto.ItemComment;
            }
            return responses;
        }
    }
}
