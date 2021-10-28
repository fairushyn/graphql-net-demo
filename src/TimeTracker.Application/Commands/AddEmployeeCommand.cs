using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Application.Notifications;
using TimeTracker.Domain.Entities;
using TimeTracker.Persistance.DbContexts;

namespace TimeTracker.Application.Commands
{
    public record AddEmployeeCommand(string FirstName, string LastName, string Email) : IRequest<Employee>;

    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly ApplicationDbContext context;
        private readonly IMediator mediator;

        public AddEmployeeCommandHandler(ApplicationDbContext context,
            IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            context.Employees.Add(employee);
            await context.SaveChangesAsync(cancellationToken);

            await mediator.Publish(new EmployeeAddedNotification(employee));

            return employee;
        }
    }
}
