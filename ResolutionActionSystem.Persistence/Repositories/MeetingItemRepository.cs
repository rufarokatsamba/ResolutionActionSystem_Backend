﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<MeetingItem>> GetMeetingItemsWithDetail()
        {
            var meetingItems = await _dbContext.MeetingItems
               .Include(q => q.Meeting)
               .ToListAsync();

            return meetingItems;
        }

        public async Task<MeetingItem> GetMeetingItemWithDetail(int id)
        {
            var meetingItem = await _dbContext.MeetingItems
               .Include(q => q.Id)
               .FirstOrDefaultAsync(q => q.Id == id);

            return meetingItem;
        }
    }
}
