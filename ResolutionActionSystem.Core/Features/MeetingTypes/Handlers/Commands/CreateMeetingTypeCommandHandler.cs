using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingType.Validators;
using ResolutionActionSystem.Application.Exceptions;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Commands;
using ResolutionActionSystem.Application.Responses;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Application.Features.MeetingTypes.Handlers.Commands
{
    public class CreateMeetingTypeCommandHandler : IRequestHandler<CreateMeetingTypeCommand, BaseCommandResponse>
    {
        private readonly IMeetingTypeRepository _meetingTypeRepository;
        private readonly IMapper _mapper;
        public CreateMeetingTypeCommandHandler(IMeetingTypeRepository meetingTypeRepository , IMapper mapper)
        {
            _meetingTypeRepository = meetingTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMeetingTypeCommand request, CancellationToken cancellationToken)
        {
            var responses = new BaseCommandResponse();
            var validator = new CreateMeetingTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateMeetingTypeDto);


            var meetingType = _mapper.Map<MeetingType>(request.CreateMeetingTypeDto);

            meetingType = await _meetingTypeRepository.Add(meetingType);
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
                responses.Name = request.CreateMeetingTypeDto.Description;
            }
            return responses;
        }
    }
}
