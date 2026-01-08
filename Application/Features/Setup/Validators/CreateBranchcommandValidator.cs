using Application.Features.Setup.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setup.Validators
{
    public class CreateBranchcommandValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchcommandValidator()
        {
            RuleFor(command => command.createBranchRequest)
                .SetValidator(new CreateBranchRequestValidator());
        }
    }
}
