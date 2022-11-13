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
    public class MeetingTypeRepository : GenericRepository<MeetingType>, IMeetingTypeRepository
    {
        private readonly ResolutionActionSystemDbContext _dbContext;
        public MeetingTypeRepository(ResolutionActionSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MeetingType> GetMeetingTypeWithDetail(int id)
        {
            var meetingItem = await _dbContext.MeetingTypes
               .OrderByDescending(q => q.Id)
                .FirstOrDefaultAsync(q => q.Id == id);

            return meetingItem;
        }
    }
}
