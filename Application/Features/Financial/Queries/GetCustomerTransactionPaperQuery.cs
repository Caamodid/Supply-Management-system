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
    public class GetCustomerTransactionPaperQuery
     : IRequest<IResponseWrapper<CustomerTransactionPaperResponse>>
    {
        public Guid CustomerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    public class GetCustomerTransactionPaperQueryHandler
        : IRequestHandler<
            GetCustomerTransactionPaperQuery,
            IResponseWrapper<CustomerTransactionPaperResponse>>
    {
        private readonly IFinancialReportService  _financialReportService;

        public GetCustomerTransactionPaperQueryHandler(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        public async Task<IResponseWrapper<CustomerTransactionPaperResponse>> Handle(
            GetCustomerTransactionPaperQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _financialReportService
                    .GetCustomerTransactionPaperAsync(
                        request.CustomerId,
                        request.FromDate,
                        request.ToDate);

                return await ResponseWrapper<CustomerTransactionPaperResponse>
                    .SuccessAsync(
                        result,
                        "Customer transaction paper retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CustomerTransactionPaperResponse>
                    .FailureAsync(
                        ex.Message,
                        "Failed to retrieve customer transaction paper.");
            }
        }
    }
}
