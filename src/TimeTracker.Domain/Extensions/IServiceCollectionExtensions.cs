using Microsoft.Extensions.DependencyInjection;

namespace TimeTracker.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
