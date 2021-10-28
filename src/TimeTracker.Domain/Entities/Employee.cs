using System;
using System.Collections.Generic;

namespace TimeTracker.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; init; }

        public string FirstName { get; init; } = string.Empty;

        public string LastName { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public ICollection<ProjectEmployee> ProjectEmployees { get; init; } = null!;
    }
}
