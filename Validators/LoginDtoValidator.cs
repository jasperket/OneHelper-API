using FluentValidation;
using OneHelper.Dto;

namespace OneHelper.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.LoginInformation).NotEmpty().NotNull().WithMessage("Login information is required");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required");
        }
    }
}
