using Application.Common.Request;
using FluentValidation;
using System;

namespace Application.Features.Setup.Validators
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .Length(3, 100).WithMessage("Category name must be between 3 and 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description)); // Validate only if description is provided

            // Optionally, you can validate the BranchId if it's not null (e.g., ensure it exists in the database)
            RuleFor(x => x.BranchId)
                .Must(ExistInDatabase).WithMessage("The Branch ID does not exist.") // Example, needs actual check for DB
                .When(x => x.BranchId.HasValue);  // Only validate if BranchId is provided
        }

        // Example method to validate that the BranchId exists in the database (stub)
        private bool ExistInDatabase(Guid? branchId)
        {
            // Replace with actual DB check to verify if the BranchId exists
            return branchId.HasValue; // Just a placeholder for now, should be replaced with real DB validation logic
        }
    }
}
