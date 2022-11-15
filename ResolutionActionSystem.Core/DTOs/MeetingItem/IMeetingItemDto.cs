using ResolutionActionSystem.Application.DTOs.Meeting;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem
{
    public interface IMeetingItemDto
    {
        public DateTime DueDate { get; set; }
        public string? PersonResponsible { get; set; }
        public string? meetingItem { get; set; }
        public string? ItemComment { get; set; }
        public int StatusId { get; set; }
        public bool? IsClosed { get; set; }
    }
}
