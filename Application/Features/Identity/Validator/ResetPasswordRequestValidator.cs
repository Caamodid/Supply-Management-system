using Application.Common.Request;
using FluentValidation;

namespace Application.Features.Identity.Validator
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            // ✅ Email Check
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100);

            //  Token Check (raw token, no username rules!)
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Reset token is required.")
                .MinimumLength(20).WithMessage("Invalid reset token.")
                .Must(t => t.Trim() == t).WithMessage("Token cannot contain leading or trailing spaces.");

            //  New Password Check
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("New password must be at least 8 characters.")
                .MaximumLength(50)
                .Matches(@"[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("New password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("New password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("New password must contain at least one special character.")
                .Must(p => p.Trim() == p).WithMessage("New password cannot start or end with spaces.");


        }
    }
}
