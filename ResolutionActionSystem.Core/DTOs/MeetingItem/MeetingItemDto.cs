using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.DTOs.MeetingType;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem
{
    public class MeetingItemDto: BaseDto
    {
        public DateTime DueDate { get; set; }
        public string? PersonResponsible { get; set; }
        public string? meetingItem { get; set; }
        public string? ItemComment { get; set; }
        public int StatusId { get; set; }
        public ItemStatusDto Status { get; set; }
        public bool? IsClosed { get; set; }
        public int MeetingId { get; set; }

    }
}
