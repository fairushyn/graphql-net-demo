using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;
using TimeTracker.Persistance.DbContexts;

namespace TimeTracker.Application.Commands
{
    public record AssignEmployeeToProjectCommand(Guid EmployeeId, Guid ProjectId, DateTime StartDate) : IRequest<ProjectEmployee>;

    public class AssignEmployeeToProjectCommandHandler : IRequestHandler<AssignEmployeeToProjectCommand, ProjectEmployee>
    {
        private readonly ApplicationDbContext context;

        public AssignEmployeeToProjectCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ProjectEmployee> Handle(AssignEmployeeToProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await context.Employees
                .FindAsync(request.EmployeeId);

            if (employee is null)
            {
                throw new NotFoundException($"Employee with id {request.EmployeeId} not found");
            }

            var project = await context.Projects
                .Include(x => x.ProjectEmployees)
                .FirstOrDefaultAsync(x => x.Id == request.ProjectId);

            if (project is null)
            {
                throw new NotFoundException($"Project with id {request.ProjectId} not found");
            }

            var projectEmployee = project.AssignEmployee(employee, request.StartDate);

            context.Entry(projectEmployee).State = EntityState.Added;

            await context.SaveChangesAsync(cancellationToken);

            return projectEmployee;
        }
    }
}
