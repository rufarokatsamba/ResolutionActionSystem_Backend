using System.Text.Json;
using System.Globalization;
using Newtonsoft.Json;

namespace ResolutionActionSystem.Application.DTOs.Meeting
{
    public class CreateMeetingDto
    {
        public string? Identifier { get; set; }
        public string? MeetingDateAndTimeToConvert { get; set; }
        public string? description { get; set; }

        DateTime dt = new DateTime();

        public DateTime? MeetingDateAndTime
        {
            get { return Convert.ToDateTime(MeetingDateAndTimeToConvert); }
        }
        public int MeetingTypeId { get; set; }

    }
}
