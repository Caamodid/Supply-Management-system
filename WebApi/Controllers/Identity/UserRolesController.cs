using Application.Common.Wrapper;
using Application.Features.Identity.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Permissions;
using System.Threading.Tasks;
using Application.Authentication;
using Application.Common.Request;
using Application.Features.Identity.Queries;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] // Require authentication for all endpoints
    public class UserRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  1️⃣ Assign role to a user
        [HttpPost("assign")]
        [MustHavePermission(AppFeature.Roles, AppAction.Manage)]
        public async Task<IActionResult> AssignRole([FromBody] AssignUserRoleRequest request)
        {
            var response = await _mediator.Send(new AssignUserRoleCommand { Request = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        //  1️⃣ Assign role to a user
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var response = await _mediator.Send(new CreateRoleCommand { Request = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }



        //  2️⃣ Remove a role from a user
        [HttpPost("remove")]
        [MustHavePermission(AppFeature.Roles, AppAction.Manage)]
        public async Task<IActionResult> RemoveRole([FromBody] RemoveUserRoleRequest request)
        {
            var response = await _mediator.Send(new RemoveUserRoleCommand { Request = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        //  3️⃣ Get all roles of a specific user
        [HttpGet("{email}/roles")]
        //[MustHavePermission(AppFeature.Roles, AppAction.View)]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            var response = await _mediator.Send(new GetUserRolesQuery { Email = email });
            return response.Success ? Ok(response) : NotFound(response);
        }



        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }





        //  4️⃣ Get all available roles in the system
        [HttpGet("all-roles")]
        //[MustHavePermission(AppFeature.Roles, AppAction.Create)]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _mediator.Send(new GetAllRolesQuery());
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
