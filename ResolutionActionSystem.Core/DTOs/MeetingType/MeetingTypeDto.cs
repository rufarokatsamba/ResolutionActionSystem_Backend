using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.Meeting;

namespace ResolutionActionSystem.Application.DTOs.MeetingType
{
    public class MeetingTypeDto: BaseDto
    {
        public string? Description { get; set; }
        public List<MeetingDto> Meeting { get; set; }
    }
}
