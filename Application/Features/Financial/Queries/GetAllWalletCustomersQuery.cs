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
    public class GetAllWalletCustomersQuery
      : IRequest<IResponseWrapper<List<CustomerWalletSimpleResponse>>>
    {
        public string? Phone { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }



    public class GetAllWalletCustomersQueryHandler
       : IRequestHandler<
           GetAllWalletCustomersQuery,
           IResponseWrapper<List<CustomerWalletSimpleResponse>>>
    {
        private readonly IFinancialReportService  _financialReportService;

        public GetAllWalletCustomersQueryHandler(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        public async Task<IResponseWrapper<List<CustomerWalletSimpleResponse>>> Handle(
            GetAllWalletCustomersQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _financialReportService.GetAllWalletCustomersAsync(
                    request.Phone,
                    request.FromDate,
                    request.ToDate);

                return await ResponseWrapper<List<CustomerWalletSimpleResponse>>
                    .SuccessAsync(
                        result,
                        "Wallet customers retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<CustomerWalletSimpleResponse>>
                    .FailureAsync(
                        ex.Message,
                        "Failed to retrieve wallet customers.");
            }
        }
    }
}
