﻿using AutoMapper;
using FluentValidation;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.DTOs.Meeting.Validators;
using ResolutionActionSystem.Application.Features.Meetings.Requests.Commands;
using ResolutionActionSystem.Application.Responses;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Application.Features.Meetings.Handlers.Commands
{
    public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand, BaseCommandResponse>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
        public CreateMeetingCommandHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var responses = new BaseCommandResponse();
            var validator = new CreateMeetingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateMeetingDto);


            var meeting = _mapper.Map<Meeting>(request.CreateMeetingDto);

            meeting = await _meetingRepository.Add(meeting);
            if (validationResult.IsValid == false)
            {
                responses.Success = false;
                responses.Message = "Creation failed";
                responses.Error = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                responses.Success = true;
                responses.Message = "Creation successful";
                responses.Name = request.CreateMeetingDto.Identifier;
            }
            return responses;
        }
    }
}
