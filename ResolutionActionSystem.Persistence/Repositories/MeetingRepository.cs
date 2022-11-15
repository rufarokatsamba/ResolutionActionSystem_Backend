using Microsoft.EntityFrameworkCore;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Persistence.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
    {
        private readonly ResolutionActionSystemDbContext _dbContext;
        public MeetingRepository(ResolutionActionSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Meeting>> GetMeetingsWithDetail()
        {
            var meetings = await _dbContext.Meetings
               .Include(q => q.MeetingType)
               .Include(q => q.MeetingItems)
               .ThenInclude(q => q.Status)
               .ToListAsync();

            return meetings;
        }
        public async Task<List<Meeting>> GetMeetingByMeetingType(int id)
        {
            var meetings = await _dbContext.Meetings
               .Where(q => q.MeetingTypeId == id)
               .Include(q => q.MeetingType)
               .ToListAsync();



            return meetings;
        }

        public async Task<Meeting> GetMeetingWithDetail(int id)
        {
            var meeting = await _dbContext.Meetings
                .OrderByDescending(q => q.Id)
                .Include(q => q.MeetingType)
                .Include(q => q.MeetingItems)
                .ThenInclude(q => q.Status)
                .FirstOrDefaultAsync(q => q.Id == id);

            return meeting;
        }
    }
}
