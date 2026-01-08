using Application.Common.Request;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.IO;  // Add this for Path
using System.Linq;  // Add this for LINQ to check the extension
using System;

namespace Application.Features.Setup.Validators
{
    public class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .Length(3, 100).WithMessage("Company name must be between 3 and 100 characters.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.Phone)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be valid. eg: +61 xx-xx xx");

            // Validate the LogoFile if it is provided
            RuleFor(x => x.LogoFile)
                .Must(BeAValidImage).WithMessage("Logo must be a valid image (JPEG, PNG).")
                .When(x => x.LogoFile != null)  // Only validate if the file is not null
                .Must(BeUnderMaxSize).WithMessage("Logo file size must be under 5 MB.");
        }

        // Custom validation for checking image type
        private bool BeAValidImage(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName)?.ToLower();
            return allowedExtensions.Contains(extension);
        }

        // Custom validation for file size (maximum 5 MB)
        private bool BeUnderMaxSize(IFormFile file)
        {
            const long maxSize = 5 * 1024 * 1024; // 5 MB
            return file.Length <= maxSize;
        }
    }
}
