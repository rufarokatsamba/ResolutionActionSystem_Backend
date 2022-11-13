using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Persistence.Repositories;

namespace ResolutionActionSystem.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //register dbcontext and add repositories to our service collections
            services.AddDbContext<ResolutionActionSystemDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ResolutionActionSystemConnectionString")));

            services.AddScoped(typeof(GenericRepository<>), typeof(Repositories.GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));//addscopped allows  services to be created once per request within the scope and gets used in other calls
            services.AddScoped<IMeetingItemRepository      , MeetingItemRepository>();
            services.AddScoped<IMeetingRepository          , MeetingRepository>();
            services.AddScoped<IItemStatusRepository       , ItemStatusRepository>();
            services.AddScoped<IMeetingTypeRepository      , MeetingTypeRepository>();
            return services;
        }
    }
}
