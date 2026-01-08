using Application.Common.Wrapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Queries
{
    public class GetAllRolesQuery
     : IRequest<ResponseWrapper<List<RoleWithCreatorDto>>>
    { }


    public class GetAllRolesQueryHandler
        : IRequestHandler<GetAllRolesQuery, ResponseWrapper<List<RoleWithCreatorDto>>>
    {
        private readonly IIdentityService _identityService;

        public GetAllRolesQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseWrapper<List<RoleWithCreatorDto>>> Handle(
            GetAllRolesQuery query,
            CancellationToken cancellationToken)
        {
            var roles = await _identityService.GetAllRolesAsync();

            if (roles == null || roles.Count == 0)
            {
                return await ResponseWrapper<List<RoleWithCreatorDto>>
                    .FailureAsync("No roles found.");
            }

            return await ResponseWrapper<List<RoleWithCreatorDto>>
                .SuccessAsync(roles, "Roles retrieved successfully.");
        }
    }
}
