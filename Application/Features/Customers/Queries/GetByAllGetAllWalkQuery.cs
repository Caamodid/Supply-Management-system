using Application.Common.Request;
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
    public class GetByAllGetAllWalkQuery : IRequest<IResponseWrapper<List<SalesListResponse>>>, IValidateMe
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }

    public class GetByAllGetAllWalkQueryHandler : IRequestHandler<GetByAllGetAllWalkQuery, IResponseWrapper<List<SalesListResponse>>>
    {
        private readonly ISalesService _salesService;
        public GetByAllGetAllWalkQueryHandler(ISalesService salesService)
        {
            _salesService = salesService;

        }
        public async Task<IResponseWrapper<List<SalesListResponse>>> Handle(GetByAllGetAllWalkQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _salesService.GetAllSalesWalkAsync(request.FromDate ,request.ToDate);
                return await ResponseWrapper<List<SalesListResponse>>.SuccessAsync(customers, "Sales list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<SalesListResponse>>.FailureAsync(ex.Message, "Failed to get sales list.");
            }
        }
    }

}
