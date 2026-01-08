using Application.Features.Employee.Commands;
using Application.Features.Employee.Validators;
using Application.Features.Identity.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Validator
{
    public class LoginUserCommandValidotor : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidotor()
        {
            RuleFor(command => command.TokenRequest)
                .SetValidator(new LoginUserCommandRequestValidator());
        }
    }
}
