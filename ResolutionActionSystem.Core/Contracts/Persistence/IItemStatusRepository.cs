using ResolutionActionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Contracts.Persistence
{
    public interface IItemStatusRepository: IGenericRepository<ItemStatus>
    {
        Task<ItemStatus> GetItemStatusWithDetail(int id);
        Task<List<ItemStatus>> GetItemStatusesWithDetail();
    }
}
