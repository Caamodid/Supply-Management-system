using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Queries.GetIncomeStatement
{
    public class GetIncomeStatementQuery
        : IRequest<IResponseWrapper<IncomeStatementResponse>>
    {
        public Guid? BranchId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class GetIncomeStatementQueryHandler
        : IRequestHandler<GetIncomeStatementQuery, IResponseWrapper<IncomeStatementResponse>>
    {
        private readonly IFinancialReportService _financialService;

        public GetIncomeStatementQueryHandler(
            IFinancialReportService financialService)
        {
            _financialService = financialService;
        }

        public async Task<IResponseWrapper<IncomeStatementResponse>> Handle(
            GetIncomeStatementQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _financialService.GetIncomeStatementAsync(
                    request.BranchId,
                    request.FromDate,
                    request.ToDate);

                return await ResponseWrapper<IncomeStatementResponse>
                    .SuccessAsync(result, "Income statement generated.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<IncomeStatementResponse>
                    .FailureAsync(ex.Message, "Failed to generate income statement.");
            }
        }
    }
}
