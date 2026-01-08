using Application.Common.Request;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Identity.Validator
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(50)
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Full name must contain only letters.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(4).WithMessage("Username must be at least 4 characters.")
                .MaximumLength(20)
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username must contain only letters, numbers, and underscore.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(50)
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(g => g == "Male" || g == "Female").WithMessage("Gender must be Male or Female.");

            //RuleFor(x => x.ProfilePictureUrl)
            //    .NotEmpty().WithMessage("Profile image is required.")
            //    .MaximumLength(250)
            //    .Must(IsValidUrl).WithMessage("Invalid profile image URL format.");
        }

        //private bool IsValidUrl(string url)
        //{
        //    return Uri.TryCreate(url, UriKind.Absolute, out _);
        //}
    }
}
