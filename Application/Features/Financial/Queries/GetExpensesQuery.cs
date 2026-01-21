using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Queries.GetExpenses
{
    public class GetExpensesQuery
        : IRequest<IResponseWrapper<List<ExpenseListResponse>>>
    {
        public Guid? BranchId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class GetExpensesQueryHandler
        : IRequestHandler<GetExpensesQuery, IResponseWrapper<List<ExpenseListResponse>>>
    {
        private readonly IFinancialReportService _service;

        public GetExpensesQueryHandler(IFinancialReportService service)
        {
            _service = service;
        }

        public async Task<IResponseWrapper<List<ExpenseListResponse>>> Handle(
            GetExpensesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.GetExpensesAsync(
                    request.BranchId,
                    request.FromDate,
                    request.ToDate);

                return await ResponseWrapper<List<ExpenseListResponse>>
                    .SuccessAsync(result, "Expenses retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<ExpenseListResponse>>
                    .FailureAsync(ex.Message, "Failed to retrieve expenses.");
            }
        }
    }
}
