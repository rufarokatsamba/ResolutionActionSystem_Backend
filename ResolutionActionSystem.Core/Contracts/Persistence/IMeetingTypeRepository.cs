using ResolutionActionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Contracts.Persistence
{
    public interface IMeetingTypeRepository: IGenericRepository<MeetingType>
    {
        Task<MeetingType> GetMeetingTypeWithDetail(int id);
    }
}
