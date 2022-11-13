using Microsoft.EntityFrameworkCore;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Persistence.Repositories
{
    public class MeetingItemRepository : GenericRepository<MeetingItem>, IMeetingItemRepository
    {
        private readonly ResolutionActionSystemDbContext _dbContext;
        public MeetingItemRepository(ResolutionActionSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMeetingItems(List<MeetingItem> meetingItems)
        {
            await _dbContext.AddRangeAsync(meetingItems);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MeetingItem>> GetMeetingItemsWithDetail()
        {
            var meetingItems = await _dbContext.MeetingItems
               .Include(q => q.Status)
               //.Include(q => q.Meeting)
               .ToListAsync();

            return meetingItems;
        }

        public async Task<MeetingItem> GetMeetingItemWithDetail(int id)
        {
            var meetingItem = await _dbContext.MeetingItems
               .OrderByDescending(q => q.Id)
                .Include(q => q.Status)
                //.Include(q => q.Meeting)
                .FirstOrDefaultAsync(q => q.Id == id);

            return meetingItem;
        }
    }
}
