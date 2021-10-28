using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Persistance.DbContexts;

namespace TimeTracker.Persistance.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config, string dbName = "TimeTrackerDb")
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(config.GetConnectionString(dbName)));

            return services;
        }
    }
}
