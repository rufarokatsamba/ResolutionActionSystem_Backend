namespace ResolutionActionSystem.Application.DTOs.Meeting
{
    public class CreateMeetingDto
    {
        public string? Description { get; set; }
        public DateTime MeetingDateAndTime { get; set; }
        public int MeetingTypeId { get; set; }
    }
}
