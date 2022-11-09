using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.ItemStatus;

namespace ResolutionActionSystem.Application.DTOs.MeetingType
{
    public class MeetingTypeDto: BaseDto
    {
        public List<ItemStatusDto> ItemStatus { get; set; }
    }
}
