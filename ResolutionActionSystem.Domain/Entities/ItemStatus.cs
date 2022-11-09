﻿using ResolutionActionSystem.Domain.Common;

namespace ResolutionActionSystem.Domain.Entities
{
    public class ItemStatus: BaseDomainEntity
    {
        public string? Description { get; set; }
        public List<MeetingItem> MeetingItems { get; set; }
    }
}
