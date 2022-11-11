using AutoMapper;
using FluentValidation;
using Moq;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Application.Features.MeetingTypes.Handlers.Commands;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Commands;
using ResolutionActionSystem.Application.Profiles;
using ResolutionActionSystem.Application.Responses;
using ResolutionActionSystem.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResolutionActionSystem.Test.MeetingTypes.Commands
{
    public class CreateMeetingTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMeetingTypeRepository> _mockRepo;
        private readonly CreateMeetingTypeDto _createMeetingTypeDto;
        private readonly CreateMeetingTypeCommandHandler _handler;
        public CreateMeetingTypeCommandHandlerTests()
        {
            _mockRepo = MockMeetingTypeRepository.GetMeetingTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateMeetingTypeCommandHandler(_mockRepo.Object, _mapper);

            _createMeetingTypeDto = new CreateMeetingTypeDto
            {
                Description = "HR"
            };
        }

        [Fact]
        public async Task Valid_MeetingType_Created()
        {
            var result = await _handler.Handle(new CreateMeetingTypeCommand() { CreateMeetingTypeDto = _createMeetingTypeDto }, CancellationToken.None);

            var meetingTypes = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();

            meetingTypes.Count.ShouldBe(4);
        }
        
    }
}
