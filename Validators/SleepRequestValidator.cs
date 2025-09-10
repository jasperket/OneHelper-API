using FluentValidation;
using OneHelper.Dto;

namespace OneHelper.Validators
{
    public class SleepRequestValidator : AbstractValidator<SleepRequest>
    {
        public SleepRequestValidator()
        {
            RuleFor(x => x.StartTime).NotNull().WithMessage("Start time is required");
        }
    }
}
