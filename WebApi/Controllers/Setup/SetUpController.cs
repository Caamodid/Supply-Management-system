using Application.Common.Request;
using Application.Features.Setup.Commands;
using Application.Features.Setup.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetUpController : BaseApiController
    {

        // POST: api/client
        [HttpPost("create-company")]
        public async Task<IActionResult> CreateCompAsync([FromForm] CreateCompanyRequest request)
        {
            var response = await Mediator.Send(new CreateCompanyCommand { createCompanyRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        // PUT: api/client/{id}
        [HttpPut("edit-company/{id}")]
        public async Task<IActionResult> UpdateCompAsync(Guid id, [FromForm] UpdateCompanyRequest request)
        {
            var response = await Mediator.Send(new UpdateCompanyCommand { Id = id,  updateCompanyRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("get-company/{id}")]
        public async Task<IActionResult> GetByIdCompAsync(Guid id)
        {
            var response = await Mediator.Send(new GetByIdCompanyQuery { Id = id });
            return response.Success ? Ok(response) : NotFound(response);
        }

        // GET: api/client
        [HttpGet("companies")]
        public async Task<IActionResult> GetAllCompAsync()
        {
            var response = await Mediator.Send(new GetByAllCompanyQuery());
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // DELETE: api/client/{id}
        [HttpDelete("delete-company{id}")]
        public async Task<IActionResult> DeleteCompAsync(Guid id)
        {
            var response = await Mediator.Send(new DeleteCompanyCommand { Id = id });
            return response.Success ? Ok(response) : BadRequest(response);
        }






        // POST: api/client
        [HttpPost("create-branch")]
        public async Task<IActionResult> CreateBranchAsync([FromBody] CreateBranchRequest request)
        {
            var response = await Mediator.Send(new CreateBranchCommand { createBranchRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // PUT: api/client/{id}
        [HttpPut("edit-branch/{id}")]
        public async Task<IActionResult> UpdateBranchAsync(Guid id, [FromBody] UpdateBranchRequest request)
        {
            var response = await Mediator.Send(new UpdateBranchCommand { Id = id,  updateBranch = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("get-branch/{id}")]
        public async Task<IActionResult> GetByIdBranchAsync(Guid id)
        {
            var response = await Mediator.Send(new GetByIdBranchQuery { Id = id });
            return response.Success ? Ok(response) : NotFound(response);
        }

        // GET: api/client
        [HttpGet("branches")]
        public async Task<IActionResult> GetAllBranchAsync()
        {
            var response = await Mediator.Send(new GetByAllBranchQuery());
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // DELETE: api/client/{id}
        [HttpDelete("delete-branch{id}")]
        public async Task<IActionResult> DeleteBranchAsync(Guid id)
        {
            var response = await Mediator.Send(new DeleteBranchCommand { Id = id });
            return response.Success ? Ok(response) : BadRequest(response);
        }





        // POST: api/client
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            var response = await Mediator.Send(new CreateCategoryCommand { createCategoryRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // PUT: api/client/{id}
        [HttpPut("edit-category/{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid id, [FromBody] UpdateCategoryRequest request)
        {
            var response = await Mediator.Send(new UpdateCategoryCommand { Id = id,  updateCategoryRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("get-category/{id}")]
        public async Task<IActionResult> GetByIdCategoryAsync(Guid id)
        {
            var response = await Mediator.Send(new GetByIdCategoryQuery { Id = id });
            return response.Success ? Ok(response) : NotFound(response);
        }

        // GET: api/client
        [HttpGet("categories")]
        public async Task<IActionResult> GetAlCategoryAsync()
        {
            var response = await Mediator.Send(new GetByAllCategoryQuery());
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // DELETE: api/client/{id}
        [HttpDelete("delete-category{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id)
        {
            var response = await Mediator.Send(new DeleteCategoryCommand { Id = id });
            return response.Success ? Ok(response) : BadRequest(response);
        }


    }
}
