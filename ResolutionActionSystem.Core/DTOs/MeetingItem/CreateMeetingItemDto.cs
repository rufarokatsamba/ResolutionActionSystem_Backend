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
        public string? Action { get; set; }
        public string? Status { get; set; }
        public bool? isClosed { get; set; }
        public int MeetingId { get; set; }
    }
}
