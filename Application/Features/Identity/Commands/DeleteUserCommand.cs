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
    public class DeleteUserCommand : IRequest<ResponseWrapper<string>>
    {
        public string UserId { get; set; }
    }

    // 🔹 Handler
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseWrapper<string>>
    {
        private readonly IUserService _userService;


        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResponseWrapper<string>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            // Call IdentityService
            var result = await _userService.DeleteUserAsync(command.UserId);

            if (!result.Success)
                return await ResponseWrapper<string>.FailureAsync(result.Message);

            return await ResponseWrapper<string>.SuccessAsync(result.Message);
        }
    }
}
