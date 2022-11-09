using ResolutionActionSystem.Domain.Common;

namespace ResolutionActionSystem.Domain.Entities
{
    public class MeetingType: BaseDomainEntity
    {
        public List<ItemStatus> ItemStatus { get; set; }
    }
}
