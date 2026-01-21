using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Financial.Queries
{
    public class GetIncomeStatementReportQuery
           : IRequest<IResponseWrapper<IncomeStatementReportResponse>>
    {
        public Guid? BranchId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }


    public class GetIncomeStatementReportQueryHandler
       : IRequestHandler<GetIncomeStatementReportQuery, IResponseWrapper<IncomeStatementReportResponse>>
    {
        private readonly IFinancialReportService _financialReportService;

        public GetIncomeStatementReportQueryHandler(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        public async Task<IResponseWrapper<IncomeStatementReportResponse>> Handle(
            GetIncomeStatementReportQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var report = await _financialReportService.GetIncomeStatementReportAsync(
                    request.BranchId,
                    request.FromDate,
                    request.ToDate);

                return await ResponseWrapper<IncomeStatementReportResponse>
                    .SuccessAsync(report, "Income statement report generated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<IncomeStatementReportResponse>
                    .FailureAsync(ex.Message, "Failed to generate income statement report.");
            }
        }
    }
}
