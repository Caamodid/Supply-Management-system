using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class LoginUserCommand : IRequest<ResponseWrapper<LoginResponse>>, IValidateMe
    {
        public TokenRequest TokenRequest { get; set; } = new();
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResponseWrapper<LoginResponse>>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResponseWrapper<LoginResponse>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(command.TokenRequest.UsernameOrEmail, command.TokenRequest.Password);
        }
    }
}
