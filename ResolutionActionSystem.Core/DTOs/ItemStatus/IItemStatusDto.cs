using ResolutionActionSystem.Application.DTOs.MeetingItem;

namespace ResolutionActionSystem.Application.DTOs.ItemStatus
{
    public interface IItemStatusDto
    {
        public string? Description { get; set; }
        public List<MeetingItemDto> MeetingItems { get; set; }
    }
}
