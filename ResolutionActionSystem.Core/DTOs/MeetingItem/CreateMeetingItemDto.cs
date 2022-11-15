using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem
{
    public class CreateMeetingItemDto
    {
        public DateTime DueDate { get; set; }
        public string? PersonResponsible { get; set; }
        public string? ItemComment { get; set; }
        public string? meetingItem { get; set; }
        public int StatusId { get; set; }
        public bool? IsClosed { get; set; }
        public int MeetingId { get; set; }

    }
}
