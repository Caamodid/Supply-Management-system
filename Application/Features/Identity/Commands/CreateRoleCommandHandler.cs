using Application.Common.Request;
using Application.Common.Wrapper;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class CreateRoleCommand : IRequest<ResponseWrapper<string>>
    {
        public CreateRoleRequest Request { get; set; }
    }

    public class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, ResponseWrapper<string>>
    {
        private readonly IIdentityService _identityService;

        public CreateRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseWrapper<string>> Handle(
            CreateRoleCommand command,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Check if role already exists
            var roleExists = await _identityService
                .RoleExistsAsync(command.Request.RoleName);

            if (roleExists)
                return await ResponseWrapper<string>
                    .FailureAsync("Role already exists.");

            // 2️⃣ Try creating role
            var success = await _identityService
                .CreateRoleAsync(
                    command.Request.RoleName,
                    command.Request.Description
                );

            // 3️⃣ Return consistent ResponseWrapper result
            if (success)
                return await ResponseWrapper<string>
                    .SuccessAsync("Role created successfully.");
            else
                return await ResponseWrapper<string>
                    .FailureAsync("Failed to create role.");
        }
    }
}
