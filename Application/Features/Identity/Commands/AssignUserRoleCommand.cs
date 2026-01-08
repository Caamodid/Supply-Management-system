using Application.Common.Request;
using Application.Common.Wrapper;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class AssignUserRoleCommand : IRequest<ResponseWrapper<string>>
    {
        public AssignUserRoleRequest Request { get; set; }
    }

    public class AssignUserRoleCommandHandler : IRequestHandler<AssignUserRoleCommand, ResponseWrapper<string>>
    {
        private readonly IIdentityService _identityService;

        public AssignUserRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseWrapper<string>> Handle(AssignUserRoleCommand command, CancellationToken cancellationToken)
        {
            // 1️⃣ Check if the role exists
            var roleExists = await _identityService.RoleExistsAsync(command.Request.RoleName);
            if (!roleExists)
                return await ResponseWrapper<string>.FailureAsync("Role does not exist.");

            // 2️⃣ Try assigning the role
            var success = await _identityService.AddUserToRoleAsync(command.Request.userId, command.Request.RoleName);

            // 3️⃣ Return consistent ResponseWrapper result
            if (success)
                return await ResponseWrapper<string>.SuccessAsync(
                    $"Role '{command.Request.RoleName}' successfully assigned .");
            else
                return await ResponseWrapper<string>.FailureAsync("Failed to assign role.");
        }
    }
}
