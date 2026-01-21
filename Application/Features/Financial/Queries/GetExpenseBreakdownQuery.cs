using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Queries.GetExpenseBreakdown
{
    // =========================
    // QUERY
    // =========================
    public class GetExpenseBreakdownQuery
        : IRequest<IResponseWrapper<List<ExpenseCategorySummaryResponse>>>
    {
        public Guid? BranchId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    // =========================
    // QUERY HANDLER
    // =========================
    public class GetExpenseBreakdownQueryHandler
        : IRequestHandler<GetExpenseBreakdownQuery, IResponseWrapper<List<ExpenseCategorySummaryResponse>>>
    {
        private readonly IFinancialReportService _financialReportService;

        public GetExpenseBreakdownQueryHandler(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        public async Task<IResponseWrapper<List<ExpenseCategorySummaryResponse>>> Handle(
            GetExpenseBreakdownQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _financialReportService.GetExpenseBreakdownAsync(
                    request.BranchId,
                    request.FromDate,
                    request.ToDate);

                return await ResponseWrapper<List<ExpenseCategorySummaryResponse>>
                    .SuccessAsync(result, "Expense breakdown retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<ExpenseCategorySummaryResponse>>
                    .FailureAsync(ex.Message, "Failed to retrieve expense breakdown.");
            }
        }
    }
}
