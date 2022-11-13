using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.DTOs.MeetingItem;

namespace ResolutionActionSystem.Application.DTOs.MeetingType
{
    public class MeetingTypeDto: BaseDto
    {
        public string? Description { get; set; }
        //public List<MeetingItemDto> MeetingItems { get; set; }
    }
}
