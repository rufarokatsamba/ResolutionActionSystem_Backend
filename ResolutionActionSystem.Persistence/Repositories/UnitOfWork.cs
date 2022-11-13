using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ResolutionActionSystem.Application.Constants;
using ResolutionActionSystem.Application.Contracts.Persistence;


namespace ResolutionActionSystem.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ResolutionActionSystemDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private IItemStatusRepository _itemStatusRepository;

        private IMeetingItemRepository _meetingItemRepository;

        private IMeetingRepository _meetingRepository;

        private IMeetingTypeRepository _meetingTypeRepository;

        public UnitOfWork(ResolutionActionSystemDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IItemStatusRepository ItemStatusRepository =>
           _itemStatusRepository ??= new ItemStatusRepository(_context);

        public IMeetingItemRepository MeetingItemRepository  =>
         _meetingItemRepository ??= new MeetingItemRepository(_context);

        public IMeetingRepository MeetingRepository  =>
         _meetingRepository ??= new MeetingRepository(_context);

        public IMeetingTypeRepository MeetingTypeRepository  =>
         _meetingTypeRepository ??= new MeetingTypeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
