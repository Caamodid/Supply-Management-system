using Application.Common.Request;
using Application.Common.Wrapper;
using Application.Features.Employee.Commands;
using Application.Features.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateRequestEmployee request)
        {
            var response = await _mediator.Send(new CreateEmployeeCommand {CreateEmployeeRequest = request });
            return response.Success? Ok(response): BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            var response = await _mediator.Send(new UpdateEmployeeCommand {UpdateEmployeeRequest = request});
            return response.Success? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var response = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return response.Success? Ok(response): NotFound(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var response = await _mediator.Send(new GetAllEmployeesQuery());
            return response.Success? Ok(response): BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });
            return response.Success? Ok(response): BadRequest(response);
        }
    }
}
