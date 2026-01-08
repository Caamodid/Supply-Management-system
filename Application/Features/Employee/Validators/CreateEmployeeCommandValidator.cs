using Application.Features.Employee.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Validators
{
 public  class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(command => command.CreateEmployeeRequest)
                .SetValidator(new CreateEmployeeRequestValidator());
        }
    }
}
