using ResolutionActionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Contracts.Persistence
{
    public interface IMeetingItemRepository: IGenericRepository<MeetingItem>
    {
        Task<MeetingItem> GetMeetingItemWithDetail(int id);
        Task<List<MeetingItem>> GetMeetingItemsWithDetail();
    }
}
