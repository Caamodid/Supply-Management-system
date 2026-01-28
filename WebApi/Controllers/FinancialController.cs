using Application.Common.Request;
using Application.Common.Response;
using Application.Features.Financial.Commands;
using Application.Features.Financial.Commands.CreateExpense;
using Application.Features.Financial.Commands.CreateExpenseCategory;
using Application.Features.Financial.Commands.EditExpenseCategory;
using Application.Features.Financial.Queries;
using Application.Features.Financial.Queries.GetExpenseBreakdown;
using Application.Features.Financial.Queries.GetExpenses;
using Application.Features.Financial.Queries.GetIncomeStatement;
using Application.Features.Financial.Queries.GetRevenueBreakdown;
using Application.Features.Setup.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : BaseApiController
    {
        // =========================
        // EXPENSE CATEGORY
        // =========================

        [HttpPost("create-expense-category")]
        public async Task<IActionResult> CreateExpenseCategory(
            [FromBody] CreateExpenseCategoryRequest request)
        {
            var response = await Mediator.Send(
                new CreateExpenseCategoryCommand { Request = request });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("edit-expense-category")]
        public async Task<IActionResult> EditExpenseCategory(
            [FromBody] EditExpenseCategoryRequest request)
        {
            var response = await Mediator.Send(
                new EditExpenseCategoryCommand { Request = request });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        // =========================
        // EXPENSE MANAGEMENT
        // =========================

        [HttpPost("create-expense")]
        public async Task<IActionResult> CreateExpense(
            [FromBody] CreateExpenseRequest request)
        {
            var response = await Mediator.Send(
                new CreateExpenseCommand { Request = request });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("expenses")]
        public async Task<IActionResult> GetExpenses(
            [FromQuery] Guid? branchId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        
        {
            var response = await Mediator.Send(new GetExpensesQuery
            {
                BranchId = branchId,
                FromDate = fromDate,
                ToDate = toDate
            });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        // =========================
        // FINANCIAL REPORTS
        // =========================

        [HttpPost("expense-breakdown")]
        public async Task<IActionResult> GetExpenseBreakdown(
            [FromQuery] Guid ? branchId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetExpenseBreakdownQuery
            {
                BranchId = branchId,
                FromDate = fromDate,
                ToDate = toDate
            });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("revenue-breakdown")]
        public async Task<IActionResult> GetRevenueBreakdown(
            [FromQuery] Guid ? branchId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetRevenueBreakdownQuery
            {
                BranchId = branchId,
                FromDate = fromDate,
                ToDate = toDate
            });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("income-statement")]
        public async Task<IActionResult> GetIncomeStatement(
            [FromQuery] Guid? branchId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetIncomeStatementQuery
            {
                BranchId = branchId,
                FromDate = fromDate,
                ToDate = toDate
            });

            return response.Success ? Ok(response) : BadRequest(response);
        }





        [HttpPost("reports/income-statement")]
        public async Task<IActionResult> GetIncomeStatementReport(
            [FromQuery] Guid? branchId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetIncomeStatementReportQuery
            {
                BranchId = branchId,
                FromDate = fromDate,
                ToDate = toDate
            });

            return response.Success ? Ok(response) : BadRequest(response);
        }



        // GET: api/client
        [HttpGet("expensesTypes")]
        public async Task<IActionResult> GetAllExpensTypeAsync()
        {
            var response = await Mediator.Send(new GetByAllExpensTypeQuery());
            return response.Success ? Ok(response) : BadRequest(response);
        }




        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(
            [FromBody] DepositCommand command)
        {
            var response = await Mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpPost("transaction")]
        public async Task<IActionResult> WalletTransaction(
            [FromBody] WalletTransactionCommand command)
        {
            var response = await Mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpGet("customers")]
        public async Task<IActionResult> GetAllWalletCustomers(
    [FromQuery] string? phone,
    [FromQuery] DateTime? fromDate,
    [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(
                new GetAllWalletCustomersQuery
                {
                    Phone = phone,
                    FromDate = fromDate,
                    ToDate = toDate
                });

            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpGet("customer-paper")]
        public async Task<IActionResult> GetCustomerTransactionPaper(
            [FromQuery] Guid customerId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(
                new GetCustomerTransactionPaperQuery
                {
                    CustomerId = customerId,
                    FromDate = fromDate,
                    ToDate = toDate
                });

            return response.Success ? Ok(response) : BadRequest(response);
        }


    }
}
