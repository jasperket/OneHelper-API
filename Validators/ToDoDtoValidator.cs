using FluentValidation;
using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Validators
{
    public class ToDoDtoValidator : AbstractValidator<ToDoRequest>
    {
        public ToDoDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().MinimumLength(1).NotNull()
                .WithMessage("Title is required");
            RuleFor(x => x.ToDoType)
                .NotEmpty()
                .NotNull().WithMessage("A type of to do is required");
            RuleFor(x => x.StartTime).NotEmpty()
                .WithMessage("Start time is required");
            RuleFor(x => x.EndTime).NotEmpty()
                .WithMessage("End time is required");
            RuleFor(x => x.PriorityLevel).NotNull().InclusiveBetween(0, 3)
                .WithMessage("Priority must be 0 to 3... priority is also required");
        }

    }
}
