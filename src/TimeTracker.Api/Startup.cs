using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeTracker.Api.ObjectTypes;
using TimeTracker.Api.Validations;
using TimeTracker.Application.Extensions;
using TimeTracker.Persistance.Extensions;

namespace TimeTracker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<TrackTimeCommandValidator>();

            services
                .AddGraphQLServer()
                .AddFairyBread()
                .AddProjections()
                .AddSorting()
                .AddFiltering()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<TimeSheetObjectType>();

            services.AddDatabase(Configuration);
            services.AddApplication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
