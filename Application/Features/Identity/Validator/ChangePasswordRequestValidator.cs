using Application.Common.Request;
using FluentValidation;

namespace Application.Features.Identity.Validator
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Old password is required.")
                .MinimumLength(8).WithMessage("Old password must be at least 8 characters.")
                .MaximumLength(50)
                .Matches(@"[A-Z]").WithMessage("Old password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Old password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Old password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("Old password must contain at least one special character.")
                .Must(p => p.Trim() == p).WithMessage("Old password cannot start or end with spaces.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("New password must be at least 8 characters.")
                .MaximumLength(50)
                .Matches(@"[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("New password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("New password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("New password must contain at least one special character.")
                .Must(p => p.Trim() == p).WithMessage("New password cannot start or end with spaces.");

            RuleFor(x => x)
                .Must(x => x.NewPassword != x.OldPassword)
                .WithMessage("New password must be different from old password.");
        }
    }
}
