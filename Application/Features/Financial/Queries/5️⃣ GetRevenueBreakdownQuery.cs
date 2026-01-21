using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Queries.GetRevenueBreakdown
{
    public class GetRevenueBreakdownQuery
        : IRequest<IResponseWrapper<List<RevenueSummaryResponse>>>
    {
        public Guid ? BranchId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class GetRevenueBreakdownQueryHandler
        : IRequestHandler<GetRevenueBreakdownQuery, IResponseWrapper<List<RevenueSummaryResponse>>>
    {
        private readonly IFinancialReportService _service;

        public GetRevenueBreakdownQueryHandler(IFinancialReportService service)
        {
            _service = service;
        }

        public async Task<IResponseWrapper<List<RevenueSummaryResponse>>> Handle(
            GetRevenueBreakdownQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.GetRevenueBreakdownAsync(
                    request.BranchId,
                    request.FromDate,
                    request.ToDate);

                return await ResponseWrapper<List<RevenueSummaryResponse>>
                    .SuccessAsync(result, "Revenue breakdown retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<RevenueSummaryResponse>>
                    .FailureAsync(ex.Message, "Failed to retrieve revenue breakdown.");
            }
        }
    }
}
