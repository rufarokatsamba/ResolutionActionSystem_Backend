using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ResolutionActionSystem.Persistence
{
    public class ResolutionActionSystemDbContextFactory : IDesignTimeDbContextFactory<ResolutionActionSystemDbContext>
    {
        public ResolutionActionSystemDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ResolutionActionSystemDbContext>();
            var connectionString = configuration.GetConnectionString("ResolutionActionSystemConnectionString");

            builder.UseSqlServer(connectionString);


            return new ResolutionActionSystemDbContext(builder.Options);
        }

    }
}
