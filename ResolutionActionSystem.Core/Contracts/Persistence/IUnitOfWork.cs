using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IItemStatusRepository ItemStatusRepository { get; }
        IMeetingItemRepository MeetingItemRepository { get; }
        IMeetingRepository MeetingRepository { get; }
        IMeetingTypeRepository MeetingTypeRepository { get; }


        Task Save();
    }
}
