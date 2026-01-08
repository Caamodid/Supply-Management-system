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
    // 🔹 Command
    public class ChangePasswordCommand : IRequest<ResponseWrapper<string>>, IValidateMe
    {
        public ChangePasswordRequest  changePasswordRequest { get; set; }
    }

    // 🔹 Handler
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResponseWrapper<string>>
    {
        private readonly IUserService _userService;

        public ChangePasswordCommandHandler(IUserService  userService)
        {
            _userService = userService;
        }

        public async Task<ResponseWrapper<string>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await _userService.ChangePasswordAsync(command.changePasswordRequest);

            if (!result.Success)
                return await ResponseWrapper<string>.FailureAsync(result.Message);

            return await ResponseWrapper<string>.SuccessAsync(result.Message);
        }
    }
}
