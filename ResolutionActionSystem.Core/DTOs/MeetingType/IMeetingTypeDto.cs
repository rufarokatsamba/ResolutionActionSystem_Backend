using ResolutionActionSystem.Application.DTOs.ItemStatus;

namespace ResolutionActionSystem.Application.DTOs.MeetingType
{
    public interface IMeetingTypeDto
    {
        public List<ItemStatusDto> ItemStatus { get; set; }
    }
}
