using AutoMapper;
using Moq;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Application.Features.MeetingTypes.Handlers.Queries;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Queries;
using ResolutionActionSystem.Application.Profiles;
using ResolutionActionSystem.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResolutionActionSystem.Test.MeetingTypes.Queries
{
    public class GetMeetingTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMeetingTypeRepository> _mockRepo;
        public GetMeetingTypeListRequestHandlerTests()
        {
            _mockRepo = MockMeetingTypeRepository.GetMeetingTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetMeetingTypeTest()
        {
            var handler = new GetMeetingTypeListRequestHandler(_mockRepo.Object ,_mapper);

            var result = await handler.Handle(new GetMeetingTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<MeetingTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
