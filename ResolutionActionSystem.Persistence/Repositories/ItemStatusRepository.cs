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
    public class ItemStatusRepository : GenericRepository<ItemStatus>, IItemStatusRepository
    {
        private readonly ResolutionActionSystemDbContext _dbContext;
        public ItemStatusRepository(ResolutionActionSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemStatus>> GetItemStatusesWithDetail()
        {
            var itemStatuses = await _dbContext.ItemStatuses
               .Include(q => q.Id)
               .ToListAsync();

            return itemStatuses;
        }

        public async Task<ItemStatus> GetItemStatusWithDetail(int id)
        {
            var itemStatus = await _dbContext.ItemStatuses
               .Include(q => q.Id)
               .FirstOrDefaultAsync(q => q.Id == id);

            return itemStatus;
        }
    }
}
