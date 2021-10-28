using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;
using TimeTracker.Persistance.DbContexts;

namespace TimeTracker.Api
{
    public class Query
    {
        #region Employees

        [UseProjection]
        public IQueryable<Employee> GetEmployeesWithProjection([Service] ApplicationDbContext context) =>
            context.Employees;

        [UseFiltering]
        public IQueryable<Employee> GetEmployeesWithFiltering([Service] ApplicationDbContext context) =>
            context.Employees;

        [UseSorting]
        public IQueryable<Employee> GetEmployeesWithSorting([Service] ApplicationDbContext context) =>
            context.Employees;

        [UsePaging(IncludeTotalCount = true)]
        public IQueryable<Employee> GetEmployeesWithPaging([Service] ApplicationDbContext context) =>
            context.Employees;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Employee> GetEmployees([Service] ApplicationDbContext context) =>
            context.Employees;

        #endregion

        #region Projects

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Project> GetProjects([Service] ApplicationDbContext context) =>
            context.Projects;

        #endregion

        #region Employee

        public async Task<Employee> GetEmployeeByIdAsync([Service] ApplicationDbContext context, Guid id) 
            => await context.Employees.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NotFoundException($"Employee with id {id} not found");

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TimeSheet> GetTimeSheets([Service] ApplicationDbContext context) =>
            context.TimeSheets;

        #endregion
    }
}
