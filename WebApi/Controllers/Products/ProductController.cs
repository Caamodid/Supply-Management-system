using Application.Common.Request;
using Application.Features.Products.Commands;
using Application.Features.Setup.Commands;
using Application.Features.Setup.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {


        // POST: api/client
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateCompAsync([FromBody] CreateProductRequest request)
        {
            var response = await Mediator.Send(new CreateProductsCommand {  createProduct = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        // POST: api/client
        [HttpPost("create-CategoryType")]
        public async Task<IActionResult> CreateCategoryTypeAsync([FromBody] CreateCategoryTypeRequest request)
        {
            var response = await Mediator.Send(new CreateCategoryTypeCommand {  createCategoryTypeRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        //[HttpPost("open-sack")]
        //public async Task<IActionResult> OpenSack(OpenProductConversionRequest request)
        //{
        //    await _productService.OpenProductConversionAsync(request);
        //    return Ok("Sack opened successfully.");
        //}








        //[HttpGet("by-branch/{branchId}")]
        //public async Task<IActionResult> GetProductsByBranch(
        // Guid branchId,
        // [FromQuery] int page = 1,
        // [FromQuery] int pageSize = 10)
        //{
        //    var response = await Mediator.Send(
        //        new GetByProductsByBranch
        //        {
        //            BranchId = branchId,
        //            Page = page,
        //            PageSize = pageSize
        //        });

        //    return response.Success ? Ok(response) : BadRequest(response);
        //}










    }
}
