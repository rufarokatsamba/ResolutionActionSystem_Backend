using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResolutionActionSystem.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Identity
{
    public class ResolutionActionIdentityDbContext : IdentityDbContext<SystemUser>
    {
        public ResolutionActionIdentityDbContext(DbContextOptions<ResolutionActionIdentityDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SystemUser>().ToTable("Users");
        }
    }
}
