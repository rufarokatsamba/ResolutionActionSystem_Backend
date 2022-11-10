using ResolutionActionSystem.Domain.Common;

namespace ResolutionActionSystem.Domain.Entities
{
    public class MeetingType: BaseDomainEntity
    {
        public string? Description { get; set; }
        public List<Meeting> Meeting { get; set; }
    }
}
