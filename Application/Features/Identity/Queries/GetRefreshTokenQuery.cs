using Application.Common.Request;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Common.Response;
using MediatR;

namespace Application.Features.Identity.Queries
{
    public class GetRefreshTokenQuery : IRequest<ResponseWrapper<LoginResponse>>
    {
        public RefreshTokenRequest RefreshTokenRequest { get; set; }
    }

    public class GetRefreshTokenQueryHandler : IRequestHandler<GetRefreshTokenQuery, ResponseWrapper<LoginResponse>>
    {
        private readonly IAuthService _authService;

        public GetRefreshTokenQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResponseWrapper<LoginResponse>> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authService.GetRefreshTokenAsync(request.RefreshTokenRequest);
        }
    }
}
