using Application.Common.Request;
using FluentValidation;

namespace Application.Features.Identity.Validator
{
    public class LoginUserCommandRequestValidator : AbstractValidator<TokenRequest>
    {
        public LoginUserCommandRequestValidator()
        {
            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty().WithMessage("Username or Email is required.")
                .MaximumLength(50)
                .Must(IsValidUsernameOrEmail).WithMessage("Enter a valid Username or Email.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .MaximumLength(50)
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character.");
        }

        private bool IsValidUsernameOrEmail(string value)
        {
            // Email validation
            if (value.Contains("@"))
                return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(value);

            // Username validation (letters, numbers, underscore, dot)
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z0-9_.]{3,50}$");
        }
    }
}
