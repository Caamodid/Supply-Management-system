using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Queries
{
    // 🔹 Query
    public class GetAllUsersQuery : IRequest<ResponseWrapper<List<UserResponses>>>
    {
    }

    // 🔹 Handler
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseWrapper<List<UserResponses>>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResponseWrapper<List<UserResponses>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null || users.Count == 0)
                return await ResponseWrapper<List<UserResponses>>.FailureAsync("No users found.");

            return await ResponseWrapper<List<UserResponses>>.SuccessAsync(users, "Users retrieved successfully.");
        }
    }
}
