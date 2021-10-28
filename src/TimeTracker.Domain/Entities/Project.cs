using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeTracker.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public ICollection<ProjectEmployee> ProjectEmployees { get; init; } = null!;

        public ProjectEmployee AssignEmployee(Employee employee, DateTime startDate)
        {
            if (ProjectEmployees.FirstOrDefault(x => x.EmployeeId == employee.Id && x.IsActive) is not null)
            {
                throw new ApplicationException($"Employee with id {employee.Id} is already assigned to the project with id {Id}");
            }

            var projectEmployee = new ProjectEmployee()
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                ProjectId = Id,
                StartDate = startDate
            };

            ProjectEmployees.Add(projectEmployee);

            return projectEmployee;
        }
    }
}
