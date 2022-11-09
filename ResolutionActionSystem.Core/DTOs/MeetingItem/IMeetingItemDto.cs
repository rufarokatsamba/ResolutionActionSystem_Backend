using ResolutionActionSystem.Application.DTOs.Meeting;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem
{
    public interface IMeetingItemDto
    {
        public DateTime DueDate { get; set; }
        public string? PersonResponsible { get; set; }
        public string? ItemComment { get; set; }
        public string? Action { get; set; }
        public string? Status { get; set; }
        public bool? isClosed { get; set; }
        public int MeetingId { get; set; }
    }
}
