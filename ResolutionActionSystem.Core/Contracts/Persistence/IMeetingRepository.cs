using ResolutionActionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Contracts.Persistence
{
    public interface IMeetingRepository: IGenericRepository<Meeting>
    {
        Task<Meeting> GetMeetingWithDetail(int id);
        Task<List<Meeting>> GetMeetingsWithDetail();

        Task<List<Meeting>> GetMeetingByMeetingType(int id);
    }
}
