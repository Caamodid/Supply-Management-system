using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries
{
    public class GetByAllInvoicesQuery : IRequest<IResponseWrapper<List<InvoiceListResponse>>>, IValidateMe
    {
        public string? InvoiceNo { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }


    public class GetByAllInvoicesQueryHandler : IRequestHandler<GetByAllInvoicesQuery, IResponseWrapper<List<InvoiceListResponse>>>
    {
        private readonly ISalesService _salesService;

        public GetByAllInvoicesQueryHandler(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IResponseWrapper<List<InvoiceListResponse>>> Handle(
            GetByAllInvoicesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // Default FromDate and ToDate if they are not provided
                var fromDate = request.FromDate ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
                var toDate = request.ToDate ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month));

                // Convert the dates to UTC
                fromDate = fromDate.ToUniversalTime();
                toDate = toDate.ToUniversalTime();

                var customers = await _salesService.GetInvoiceListAsync(
                    request.InvoiceNo,
                    fromDate,
                    toDate
                );

                return await ResponseWrapper<List<InvoiceListResponse>>
                    .SuccessAsync(customers, "Invoice list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<InvoiceListResponse>>
                    .FailureAsync(ex.Message, "Failed to get Invoice list.");
            }
        }

    }

}
