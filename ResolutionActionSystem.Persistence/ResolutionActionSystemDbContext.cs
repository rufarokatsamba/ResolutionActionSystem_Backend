using Microsoft.EntityFrameworkCore;
using ResolutionActionSystem.Domain.Common;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Persistence
{
    public class ResolutionActionSystemDbContext : AuditableDbContext
    {
        public ResolutionActionSystemDbContext(DbContextOptions<ResolutionActionSystemDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResolutionActionSystemDbContext).Assembly);
        }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }

    }
}
