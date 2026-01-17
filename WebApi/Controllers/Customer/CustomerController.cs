using Application.Common.Request;
using Application.Features.Customers.Commands;
using Application.Features.Customers.Queries;
using Application.Features.Setup.Commands;
using Application.Features.Setup.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {

        // POST: api/client
        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomAsync([FromBody] CreateCustomerRequest request)
        {
            var response = await Mediator.Send(new CreateCustomerCommand {  CreateCustomerRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        // PUT: api/client/{id}
        [HttpPut("edit-customer/{id}")]
        public async Task<IActionResult> UpdateCustomAsync(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            var response = await Mediator.Send(new UpdateCustomerCommand { Id = id,  updateCustomer = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        // GET: api/client
        [HttpGet("customer-lists")]
        public async Task<IActionResult> GetAllCustomAsync([FromQuery] DateTime? fromDate,[FromQuery] DateTime? toDate,[FromQuery] string? phone)
        {
            var response = await Mediator.Send(new GetByAllCustomerQuery
            {
                FromDate = fromDate,
                ToDate = toDate,
                Phone = phone
            });

            return response.Success ? Ok(response) : BadRequest(response);
        }


        // DELETE: api/client/{id}
        [HttpDelete("delete-customer/{id}")]
        public async Task<IActionResult> DeleteCustomAsync(Guid id)
        {
            var response = await Mediator.Send(new DeleteCustomerCommand { Id = id });
            return response.Success ? Ok(response) : BadRequest(response);
        }


        // POST: api/client
        [HttpPost("cancel-sale")]
        public async Task<IActionResult> CancelSaleAsync([FromBody] CancelSaleRequest request)
        {
            var response = await Mediator.Send(new CreateSalesCancelCommand {  cancelSaleRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // POST: api/client
        [HttpPost("paid-remaining")]
        public async Task<IActionResult> PayRemainingAsync([FromBody] PayRemainingRequest request)
        {
            var response = await Mediator.Send(new CreatePayRemainingCommand {  payRemainingRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        // POST: api/client
        [HttpPost("create-sales")]
        public async Task<IActionResult> CreateSaleWithItemsAsync([FromBody] CreateSalesAndSaleItemRequest request)
        {
            var response = await Mediator.Send(new CreateSalesCommand {  CreateSalesAndSaleItemRequest = request });
            return response.Success ? Ok(response) : BadRequest(response);
        }



        // POST: api/client
        [HttpPost("sales-lists")]
        public async Task<IActionResult> GetAllSalesAsync()
        {
            var response = await Mediator.Send(new GetByAllGetAllSalesQuery { });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        // POST: api/client
        [HttpPost("customer-credits")]
        public async Task<IActionResult> GetCustomerCreditsAsync(  [FromQuery] string? invoiceNo =null, [FromQuery] DateTime? fromDate =null,[FromQuery] DateTime? toDate=null)
        {
            var query = new GetCustomerCreditsQuery
            {InvoiceNo = invoiceNo,FromDate = fromDate, ToDate = toDate
            };

            var response = await Mediator.Send(query);
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPut("edit-sale")]
        public async Task<IActionResult> EditSale([FromBody] EditSaleRequest request)
        {
            await Mediator.Send(new EditSaleCommand { Request = request });
            return Ok("Sale updated successfully");
        }



        // POST: api/client
        [HttpPost("credits-detail/{CustomerId}")]
        public async Task<IActionResult> GetCustomerCreditDetailAsync( Guid CustomerId)
        {
            var response = await Mediator.Send(new GetCustomerCreditDetailQuery { Id = CustomerId });
            return response.Success ? Ok(response) : BadRequest(response);
        }




        // POST: api/client
        [HttpPost("SaleDetail/{SaleId}")]
        public async Task<IActionResult> GetSaleDetailAsync(Guid SaleId )
        {
            var response = await Mediator.Send(new GetByIdSaleDetailQuery {Id = SaleId });
            return response.Success ? Ok(response) : BadRequest(response);
        }





    }
}
