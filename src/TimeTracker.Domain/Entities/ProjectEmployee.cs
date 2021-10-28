using System;
using System.Collections.Generic;

namespace TimeTracker.Domain.Entities
{
    public class ProjectEmployee
    {
        public Guid Id { get; init; }

        public Guid ProjectId { get; init; }

        public Project Project { get; init; } = null!;

        public Guid EmployeeId { get; init; }

        public Employee Employee { get; init; } = null!;

        public DateTime StartDate { get; init; }

        public DateTime? EndDate { get; init; }

        public bool IsActive
        {
            get
            {
                return EndDate is null || EndDate <= DateTime.Today;
            }

            private set { }
        }

        public ICollection<TimeSheet> TimeSheets { get; init; } = null!;
    }
}
