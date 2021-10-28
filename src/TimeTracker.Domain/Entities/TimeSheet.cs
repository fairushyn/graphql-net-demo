using System;
using TimeTracker.Domain.Enums;

namespace TimeTracker.Domain.Entities
{
    public class TimeSheet
    {
        public Guid Id { get; init; }

        public Guid ProjectEmployeeId { get; init; }

        public ProjectEmployee ProjectEmployee { get; init; } = null!;

        public DateTime Date { get; init; }

        public TrackTimeType TrackTimeType { get; init; }

        public decimal Hours { get; init; }

        public string? Description { get; init; }

        public Guid? ApprovedByEmployeeId { get; init; }
    }
}
