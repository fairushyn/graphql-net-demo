using FluentValidation;
using TimeTracker.Application.Commands;

namespace TimeTracker.Api.Validations
{
    public class TrackTimeCommandValidator : AbstractValidator<TrackTimeCommand>
    {
        public TrackTimeCommandValidator()
        {
            RuleFor(x => x.Hours).GreaterThan(0m).WithMessage("Hours should be greater than 0");
            RuleFor(x => x.Hours).LessThan(24m).WithMessage("Hours should be less than 24");
        }
    }
}
