using Application.Common.Request;
using Application.Common.Wrapper;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class ResetPasswordCommand : IRequest<ResponseWrapper<string>>
    {
        public ResetPasswordRequest Request { get; set; }
    }

    // 🔹 Handler
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResponseWrapper<string>>
    {
        private readonly IUserService _userService;

        public ResetPasswordCommandHandler(IUserService _userService)
        {
            _userService = _userService;
        }

        public async Task<ResponseWrapper<string>> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            if (command?.Request == null)
                return await ResponseWrapper<string>.FailureAsync("Invalid request payload.");

            var result = await _userService.ResetPasswordAsync(command.Request);

            if (result == null)
                return await ResponseWrapper<string>.FailureAsync("Unexpected error: identity service returned null.");

            if (!result.Success)
                return await ResponseWrapper<string>.FailureAsync(result.Message);

            return await ResponseWrapper<string>.SuccessAsync(result.Message);
        }
    }
}
