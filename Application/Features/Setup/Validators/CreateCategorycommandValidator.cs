using Application.Features.Setup.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setup.Validators
{
    internal class CreateCategorycommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategorycommandValidator()
        {
            RuleFor(command => command.createCategoryRequest)
                .SetValidator(new CreateCategoryRequestValidator());
        }
    }
}
