using Application.Common.Request;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class CreateUserCommand : IRequest<ResponseWrapper<string>>, IValidateMe
    {
        public CreateUserRequest  createUserRequest { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseWrapper<string>>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResponseWrapper<string>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var created = await _userService.CreateUserAsync(command.createUserRequest);

            if (!created.Success)
                return await ResponseWrapper<string>.FailureAsync("Failed to create user. The email might already exist or validation failed.");

            return await ResponseWrapper<string>.SuccessAsync("User created successfully.");
        }
    }
}
