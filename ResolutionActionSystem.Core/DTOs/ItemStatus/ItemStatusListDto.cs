using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.MeetingItem;

namespace ResolutionActionSystem.Application.DTOs.ItemStatus
{
    public class ItemStatusListDto : BaseDto
    {
        public string? Description { get; set; }
        //public List<MeetingItemDto> MeetingItems { get; set; }
    }
}