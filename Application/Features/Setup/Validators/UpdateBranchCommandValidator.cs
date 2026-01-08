using Application.Features.Setup.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setup.Validators
{
    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {

        public UpdateBranchCommandValidator()
        {
            RuleFor(command => command.updateBranch)
                .SetValidator(new UpdateBranchRequestValidator());
        }
    }
}
