using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistance.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; init; } = null!;
        public DbSet<Employee> Employees { get; init; } = null!;
        public DbSet<ProjectEmployee> ProjectEmployees { get; init; } = null!;
        public DbSet<TimeSheet> TimeSheets { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>()
                .Property(x => x.IsActive)
                .ValueGeneratedOnAdd();
        }
    }
}
