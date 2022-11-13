using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Identity
{
    public class ResolutionActionIdentityDbContextFactory : IDesignTimeDbContextFactory<ResolutionActionIdentityDbContext>
    {
        public ResolutionActionIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ResolutionActionIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("ResolutionActionSystemConnectionString");

            builder.UseSqlServer(connectionString);

            return new ResolutionActionIdentityDbContext(builder.Options);
        }
    }
}
