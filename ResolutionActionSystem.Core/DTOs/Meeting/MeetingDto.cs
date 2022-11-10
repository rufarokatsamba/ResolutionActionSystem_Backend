using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.MeetingItem;
using ResolutionActionSystem.Application.DTOs.MeetingType;

namespace ResolutionActionSystem.Application.DTOs.Meeting
{
    public class MeetingDto: BaseDto
    {
        public string? Description { get; set; }
        public DateTime MeetingDateAndTime { get; set; }
        public MeetingTypeDto MeetingType { get; set; }
        public int MeetingTypeId { get; set; }
        public List<MeetingItemDto> MeetingItems { get; set; }
    }
}
