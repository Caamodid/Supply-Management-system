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
    public class UpdateRoleCommandHandler
         : IRequestHandler<UpdateRoleCommand, ResponseWrapper<bool>>
    {
        private readonly IIdentityService _identityService;

        public UpdateRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseWrapper<bool>> Handle(
            UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            await _identityService.UpdateRoleAsync(
                request.RoleId,
                request.Name,
                request.Description
            );

            return await ResponseWrapper<bool>
                .SuccessAsync(true, "Role updated successfully.");
        }
    }
}
