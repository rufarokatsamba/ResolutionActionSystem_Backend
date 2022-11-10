using Microsoft.EntityFrameworkCore;
using ResolutionActionSystem.Domain.Common;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Persistence
{
    public class ResolutionActionSystemDbContext : DbContext
    {
        public ResolutionActionSystemDbContext(DbContextOptions<ResolutionActionSystemDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResolutionActionSystemDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //audit logging
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }

    }
}
