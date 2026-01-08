using Application.Common.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Validator
{
    public class UpdateUserRequestValidator: AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
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
