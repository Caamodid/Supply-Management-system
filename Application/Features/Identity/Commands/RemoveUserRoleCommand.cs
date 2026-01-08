using Application.Common.Request;
using Application.Common.Wrapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class RemoveUserRoleCommand : IRequest<ResponseWrapper<string>>
    {
        public RemoveUserRoleRequest Request { get; set; }
    }

    public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommand, ResponseWrapper<string>>
    {
        private readonly IIdentityService _identityService;

        public RemoveUserRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseWrapper<string>> Handle(RemoveUserRoleCommand command, CancellationToken cancellationToken)
        {
            var success = await _identityService.RemoveUserFromRoleAsync(command.Request.userId, command.Request.RoleName);

            if (success)
                return await ResponseWrapper<string>.SuccessAsync($"Role '{command.Request.RoleName}' removed from userId: {command.Request.userId}");
            else
                return await ResponseWrapper<string>.FailureAsync("Failed to remove role or user not found.");
        }
    }
}
