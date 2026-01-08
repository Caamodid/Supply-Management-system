using Application.Authentication;
using Application.Common.Request;
using Application.Common.Response;
using Application.Features.Identity.Commands;
using Application.Features.Identity.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Permissions;

namespace WebApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  1️⃣ Assign role to a user
        [HttpPost("create")]
        //[MustHavePermission(AppFeature.Roles, AppAction.Manage)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            var response = await _mediator.Send(new CreateUserCommand { createUserRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPut("edit")]
        //[MustHavePermission(AppFeature.Roles, AppAction.Edit)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequest request)
        {
            var response = await _mediator.Send(new UpdateUserCommand { updateUserRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var response = await _mediator.Send(new DeleteUserCommand { UserId = userId });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = await _mediator.Send(new ChangePasswordCommand { changePasswordRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = await _mediator.Send(new ResetPasswordCommand { Request = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        //  1️⃣ Assign role to a user
        [HttpGet("all")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest command)
        {
            var response = await _mediator.Send(new LoginUserCommand { TokenRequest= command } );
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPost("refresh-token")]
        public async Task<IActionResult> GetRefreshTokenAsync([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var response = await _mediator.Send(
                new GetRefreshTokenQuery { RefreshTokenRequest = refreshTokenRequest });
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
