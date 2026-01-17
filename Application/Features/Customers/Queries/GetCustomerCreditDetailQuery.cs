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
    public class GetCustomerCreditDetailQuery
        : IRequest<IResponseWrapper<CustomerCreditDetailResponse>>, IValidateMe
    {
        public Guid Id { get; set; }
    }
    public class GetCustomerCreditDetailQueryHandler
        : IRequestHandler<GetCustomerCreditDetailQuery, IResponseWrapper<CustomerCreditDetailResponse>>
    {
        private readonly ISalesService _salesService;

        public GetCustomerCreditDetailQueryHandler(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IResponseWrapper<CustomerCreditDetailResponse>> Handle(
            GetCustomerCreditDetailQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var saleDetail = await _salesService.GetCustomerCreditDetailAsync(request.Id);

                return await ResponseWrapper<CustomerCreditDetailResponse>
                    .SuccessAsync(saleDetail, "Customer credit detail retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CustomerCreditDetailResponse>
                    .FailureAsync(ex.Message, "Failed to get Customer credit details.");
            }
        }
    }


}

