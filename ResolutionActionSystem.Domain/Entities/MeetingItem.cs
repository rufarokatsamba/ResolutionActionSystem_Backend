using ResolutionActionSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Domain.Entities
{
    public class MeetingItem : BaseDomainEntity
    {
        public DateTime DueDate { get; set; }
        public string? PersonResponsible { get; set; }
        public string? ItemComment { get; set; }
        public string? Action { get; set; }
        public string? Status { get; set; }
        public bool? IsClosed { get; set; }
        public Meeting Meeting { get; set; }
        public int MeetingId { get; set; }
    }
}
