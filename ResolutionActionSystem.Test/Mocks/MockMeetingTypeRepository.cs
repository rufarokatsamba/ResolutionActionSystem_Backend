using Moq;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Test.Mocks
{
    public static class MockMeetingTypeRepository
    {
        public static Mock<IMeetingTypeRepository> GetMeetingTypeRepository()
        {
            var meetingTypes = new List<MeetingType>
            {
                new MeetingType
                {
                    Id = 1,
                    Description ="Finance"
                },
                new MeetingType
                {
                    Id = 2,
                    Description ="MANCO"
                },
                new MeetingType
                {
                    Id = 3,
                    Description ="Project Team Leaders meeting (PTL)"
                }
            };

            var mockRepo = new Mock<IMeetingTypeRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(meetingTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<MeetingType>())).ReturnsAsync((MeetingType meetingType) =>
            {
                meetingTypes.Add(meetingType);
                return meetingType;
            });

            return mockRepo;

        }
    }
}
