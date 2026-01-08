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
    // 🔹 Command
    public class ConfirmEmailCommand : IRequest<ResponseWrapper<string>>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }

    // 🔹 Handler
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ResponseWrapper<string>>
    {
        private readonly IUserService _userService;
        public ConfirmEmailCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResponseWrapper<string>> Handle(ConfirmEmailCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.UserId) || string.IsNullOrEmpty(command.Token))
                return await ResponseWrapper<string>.FailureAsync("Invalid confirmation request.");

            var result = await _userService.ConfirmEmailAsync(command.UserId, command.Token);

            if (result == null)
                return await ResponseWrapper<string>.FailureAsync("Unexpected error: identity service returned null.");

            if (!result.Success)
                return await ResponseWrapper<string>.FailureAsync(result.Message);

            return await ResponseWrapper<string>.SuccessAsync(result.Message);
        }
    }
}
