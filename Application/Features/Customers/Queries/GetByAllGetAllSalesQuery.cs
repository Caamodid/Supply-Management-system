using Application.Common.Request;
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
    public class GetByAllGetAllSalesQuery : IRequest<IResponseWrapper<List<SalesListResponse>>>, IValidateMe
    {
    }

    public class GetByAllGetAllSalesQueryHandler : IRequestHandler<GetByAllGetAllSalesQuery, IResponseWrapper<List<SalesListResponse>>>
    {
        private readonly ISalesService  _salesService;
        public GetByAllGetAllSalesQueryHandler(ISalesService salesService)
        {
            _salesService = salesService;

        }
        public async Task<IResponseWrapper<List<SalesListResponse>>> Handle(GetByAllGetAllSalesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _salesService.GetAllSalesAsync();
                return await ResponseWrapper<List<SalesListResponse>>.SuccessAsync(customers, "Sales list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<SalesListResponse>>.FailureAsync(ex.Message, "Failed to get sales list.");
            }
        }
    }

}
