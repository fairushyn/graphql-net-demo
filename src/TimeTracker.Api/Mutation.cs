using HotChocolate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Application.Commands;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Api
{
    public class Mutation
    {
        public async Task<Employee> AddEmployeeAsync(
            [Service] IMediator mediator,
            AddEmployeeCommand command,
            CancellationToken cancellationToken)
            => await mediator.Send(command, cancellationToken);

        public async Task<Project> AddProjectAsync(
            [Service] IMediator mediator,
            AddProjectCommand command,
            CancellationToken cancellationToken)
            => await mediator.Send(command, cancellationToken);

        public async Task<ProjectEmployee> AssignEmployeeToProjectAsync(
            [Service] IMediator mediator,
            AssignEmployeeToProjectCommand command,
            CancellationToken cancellationToken)
            => await mediator.Send(command, cancellationToken);

        public async Task<TimeSheet> TrackTimeAsync(
            [Service] IMediator mediator,
            TrackTimeCommand command,
            CancellationToken cancellationToken)
            => await mediator.Send(command, cancellationToken);
    }
}
