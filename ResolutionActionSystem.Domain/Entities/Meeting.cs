using ResolutionActionSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Domain.Entities
{
    public class Meeting: BaseDomainEntity
    {
        public string? Identifier { get; set; }
        public DateTime MeetingDateAndTime { get; set; }
        public MeetingType MeetingType { get; set; }
        public int MeetingTypeId { get; set; }
        public List<MeetingItem> MeetingItems { get; set; }
    }
}
