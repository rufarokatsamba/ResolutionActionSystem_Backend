using ResolutionActionSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Domain.Entities
{
    public class ItemStatus: BaseDomainEntity
    {
        public string? Description { get; set; }
        public List<MeetingItem> MeetingItems { get; set; }
    }
}
