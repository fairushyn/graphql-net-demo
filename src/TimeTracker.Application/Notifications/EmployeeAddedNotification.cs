using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Notifications
{
    internal record EmployeeAddedNotification(Employee Employee) : INotification;

    internal class SendEmployeeWelcomeEmailHandler : INotificationHandler<EmployeeAddedNotification>
    {
        private readonly ILogger<SendEmployeeWelcomeEmailHandler> logger;

        public SendEmployeeWelcomeEmailHandler(ILogger<SendEmployeeWelcomeEmailHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(EmployeeAddedNotification notification, CancellationToken cancellationToken)
        {
            var employee = notification.Employee;

            try
            {

                var template = $"Welcome {employee.FirstName} {employee.LastName}!";

                //TODO: send email

                logger.LogInformation("Successfully sent email to employee {EmployeeId}", employee.Id);
            } 
            catch(Exception ex)
            {
                logger.LogError(ex, "Failed to send welcome email to employee {EmployeeId}", employee.Id);

                //TODO: add message to queue to send later
            }

            return Task.CompletedTask;
        }
    }

    internal class CreateLegalDocumentsRequestHandler : INotificationHandler<EmployeeAddedNotification>
    {
        private readonly ILogger<CreateLegalDocumentsRequestHandler> logger;

        public CreateLegalDocumentsRequestHandler(ILogger<CreateLegalDocumentsRequestHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(EmployeeAddedNotification notification, CancellationToken cancellationToken)
        {
            var employee = notification.Employee;

            try
            {
                //TODO: add employee to queue to generate documents
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Failed to create document request for employee {EmployeeId}", employee.Id);

                //TODO: add message to DLQ
            }

            return Task.CompletedTask;
        }
    }
}
