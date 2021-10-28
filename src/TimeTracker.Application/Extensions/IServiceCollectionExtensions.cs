using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Application.Commands;

namespace TimeTracker.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddEmployeeCommand).Assembly);

            return services;
        }
    }
}
