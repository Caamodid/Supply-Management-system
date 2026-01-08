using Application.Common.Wrapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Queries
{
    public class GetUserRolesQuery : IRequest<ResponseWrapper<IList<string>>>
    {
        public string Email { get; set; }
    }

    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, ResponseWrapper<IList<string>>>
    {
        private readonly IIdentityService _identityService;

        public GetUserRolesQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseWrapper<IList<string>>> Handle(GetUserRolesQuery query, CancellationToken cancellationToken)
        {
            var roles = await _identityService.GetUserRolesAsync(query.Email);
            if (roles == null || roles.Count == 0)
                return await ResponseWrapper<IList<string>>.FailureAsync("No roles found for this user.");

            return await ResponseWrapper<IList<string>>.SuccessAsync(roles, "Roles retrieved successfully.");
        }
    }
}
