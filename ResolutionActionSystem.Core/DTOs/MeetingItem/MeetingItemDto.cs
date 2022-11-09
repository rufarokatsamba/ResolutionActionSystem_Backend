using ResolutionActionSystem.Application.DTOs.Common;
using ResolutionActionSystem.Application.DTOs.Meeting;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem
{
    public class MeetingItemDto: BaseDto
    {
        public DateTime DueDate { get; set; }
        public string? PersonResponsible { get; set; }
        public string? ItemComment { get; set; }
        public string? Action { get; set; }
        public string? Status { get; set; }
        public bool? isClosed { get; set; }
        public MeetingDto Meeting { get; set; }
        public int MeetingId { get; set; }
    }
}
