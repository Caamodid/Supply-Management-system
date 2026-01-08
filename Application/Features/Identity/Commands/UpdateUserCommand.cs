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
    public class UpdateUserCommand : IRequest<ResponseWrapper<string>>, IValidateMe
    {
        public UpdateUserRequest  updateUserRequest { get; set; }
    }

    // 🔹 Handler
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseWrapper<string>>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResponseWrapper<string>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUserAsync(command.updateUserRequest);

            if (!result.Success)
                return await ResponseWrapper<string>.FailureAsync(result.Message);

            return await ResponseWrapper<string>.SuccessAsync(result.Message);
        }
    }
}
