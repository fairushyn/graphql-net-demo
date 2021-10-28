using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using TimeTracker.Persistance.DbContexts;

namespace TimeTracker.Application.Commands
{
    public record AddProjectCommand(string Name) : IRequest<Project>;

    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, Project>
    {
        private readonly ApplicationDbContext context;

        public AddProjectCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Project> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync(cancellationToken);

            return project;
        }
    }
}
