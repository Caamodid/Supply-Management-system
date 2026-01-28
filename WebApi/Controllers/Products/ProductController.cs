using Application.Common.Request;
using Application.Features.Products.Commands;
using Application.Features.Products.Queries;
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
        public async Task<IActionResult> CreateProctAsync([FromBody] CreateProductRequest request)
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



        // PUT: api/client/{id}
        [HttpPut("edit-CategoryType/{id}")]
        public async Task<IActionResult> UpdateCategoryTypeAsync(Guid id, [FromForm] UpdateCategoryTypeRequest request)
        {
            var response = await Mediator.Send(new UpdateCategoryTypeCommand { Id = id,  updateCategoryType = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }





        // POST: api/client
        [HttpPost("create-adjustStock")]
        public async Task<IActionResult> AdjustStockAsync([FromBody] StockAdjustmentRequest request)
        {
            var response = await Mediator.Send(new CreateAdjustStockCommand { stockAdjustment = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        [HttpPost("create-ReceiveStockAsync")]
        public async Task<IActionResult> ReceiveStockAsync([FromBody] ReceiveStockRequest request)
        {
            var response = await Mediator.Send(new CreateReceiveStockCommand {  receiveStockRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPost("create-StockTransfer")]
        public async Task<IActionResult> TransferStockAsync([FromBody] StockTransferRequest request)
        {
            var response = await Mediator.Send(new CreateAStockTransferCommand {  stockTransferRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPost("create-convertStock")]
        public async Task<IActionResult> OpenProductConversionAsync([FromBody] OpenProductConversionRequest request)
        {
            var response = await Mediator.Send(new CreateOpenProductConversionCommand {  openProductConversion = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        //[HttpPost("open-sack")]
        //public async Task<IActionResult> OpenSack(OpenProductConversionRequest request)
        //{
        //    await _productService.OpenProductConversionAsync(request);
        //    return Ok("Sack opened successfully.");
        //}




        //-[HttpPost("stock-adjustment")]
        //public async Task<IActionResult> AdjustStock(StockAdjustmentRequest request)
        //{
        //    await _productService.AdjustStockAsync(request);
        //    return Ok("Stock adjusted successfully.");
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


        [HttpGet("stock-list")]
        public async Task<IActionResult> GetStockList([FromQuery] Guid? branchId)
        {
            var response = await Mediator.Send(new GetByAllStockListQuery {  BranchId = branchId });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpGet("products")]
        public async Task<IActionResult> GetProduct()
        {
            var response = await Mediator.Send(new GetProductQuery { });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("products-qnty")]
        public async Task<IActionResult> GetProductWithQnty()
        {
            var response = await Mediator.Send(new GetByAllProdQntyQuery { });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        [HttpGet("product-list")]
        public async Task<IActionResult> GetProductList()
        {
            var response = await Mediator.Send(
                new GetByAllProdByBranchPagedQuery
                {

                });

            return response.Success ? Ok(response) : BadRequest(response);
        }





        [HttpGet("category-list")]
        public async Task<IActionResult> GetCategoryType()
        {
            var response = await Mediator.Send(new GetByAllCategoryTypeQuery { });
            return response.Success ? Ok(response) : BadRequest(response);
        }



        // POST: api/client
        [HttpPost("stockMovements-list")]
        public async Task<IActionResult> GetAllStockMovementsAsync(DateTime? fromDate, DateTime? toDate)
        {
            // Create a new query object and pass the fromDate and toDate parameters
            var query = new GetByAllSGetAllStockMovementsQuery
            {
                fromDate = fromDate,
                toDate = toDate
            };

            // Send the query via Mediator to get the response
            var response = await Mediator.Send(query);

            // Return the appropriate response based on the result
            return response.Success ? Ok(response) : BadRequest(response);
        }




        [HttpPost("stockTransfers-list")]
        public async Task<IActionResult> GetAllStockTransfersAsync()
        {
            var response = await Mediator.Send(new GetByAllGetAllStockTransfersQuery { });
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPost("stocklistwithCategory-list")]
        public async Task<IActionResult> ProductWithCategoryAndWithCategoryTypeAsync()
        {
            var response = await Mediator.Send(new GetByAllGetAllProductWithCategoryAndWithCategoryTypeQuery { });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id ,[FromBody] UpdateProductRequest request)
        {
            var response = await Mediator.Send(
                new UpdateProductsCommand
                {
                    Id = id,
                    UpdateProduct = request
                });

            return response.Success
                ? Ok(response)
                : BadRequest(response);
        }








    }
}
