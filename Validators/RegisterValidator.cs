using FluentValidation;
using OneHelper.Dto;

namespace OneHelper.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty()
                   .WithMessage("Username is required");
            RuleFor(x => x.Password).NotNull().NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.Gender).NotNull().NotEmpty()
                .WithMessage("Gender is required");
            RuleFor(x => x.DateOfBirth).NotNull()
                .WithMessage("DateOfBirth is required");
            RuleFor(x => x.FirstName).NotNull().NotEmpty()
                .WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotNull().NotEmpty()
                .WithMessage("LastName is required");
            RuleFor(x => x.Height).NotNull().NotEmpty().GreaterThan(0)
                .WithMessage("Height is required");
            RuleFor(x => x.Weight).NotNull().NotEmpty().GreaterThan(0)
                .WithMessage("Weight is required");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Email must be a valid email address");
        }
    }
}
