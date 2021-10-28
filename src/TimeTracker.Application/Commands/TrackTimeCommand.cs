using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Enums;
using TimeTracker.Domain.Exceptions;
using TimeTracker.Persistance.DbContexts;

namespace TimeTracker.Application.Commands
{
    public record TrackTimeCommand(
        Guid EmployeeId,
        Guid ProjectId,
        DateTime Date,
        TrackTimeType Type,
        decimal Hours,
        string? Description) : IRequest<TimeSheet>;

    public class TrackTimeCommandHandler : IRequestHandler<TrackTimeCommand, TimeSheet>
    {
        private readonly ApplicationDbContext context;

        public TrackTimeCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TimeSheet> Handle(TrackTimeCommand request, CancellationToken cancellationToken)
        {
            var projectEmployee = await context.ProjectEmployees
                .Where(x => x.EmployeeId == request.EmployeeId
                    && x.ProjectId == request.ProjectId
                    && x.IsActive)
                .FirstOrDefaultAsync();

            if (projectEmployee is null)
            {
                throw new NotFoundException($"Active employee with id {request.EmployeeId} not found on the project with id {request.ProjectId}");
            }

            var timeSheet = new TimeSheet()
            {
                Id = Guid.NewGuid(),
                ProjectEmployeeId = projectEmployee.Id,
                Date = request.Date.Date,
                TrackTimeType = request.Type,
                Hours = request.Hours,
                Description = request.Description
            };

            context.TimeSheets.Add(timeSheet);

            await context.SaveChangesAsync(cancellationToken);

            return timeSheet;
        }
    }
}
