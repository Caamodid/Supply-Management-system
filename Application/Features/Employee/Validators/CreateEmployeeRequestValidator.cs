using Application.Common.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Validators
{
  public class CreateEmployeeRequestValidator : AbstractValidator<CreateRequestEmployee>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(request => request.FirstName)
                .NotEmpty().WithMessage("Employee firstname is required.")
                .MaximumLength(60);
            RuleFor(request => request.LastName)
                .NotEmpty().WithMessage("Employee lastname is required.")
                .MaximumLength(60);
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Employee email is required.")
                .MaximumLength(100);
            RuleFor(request => request.Position)
                .NotEmpty().WithMessage("Employee must have a Position.");
        }

    }
}
