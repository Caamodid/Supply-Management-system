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
