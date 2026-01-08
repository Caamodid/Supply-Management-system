using Application.Common.Request;
using FluentValidation;
using System;

namespace Application.Features.Setup.Validators
{
    public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
    {
        public CreateBranchRequestValidator()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.");

            RuleFor(x => x.BranchName)
                .NotEmpty().WithMessage("Branch name is required.")
                .Length(3, 100).WithMessage("Branch name must be between 3 and 100 characters.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.Phone)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be valid. Example: +61 xx-xx-xx")
                .When(x => !string.IsNullOrEmpty(x.Phone));  // Validate phone only if provided
        }
    }
}
