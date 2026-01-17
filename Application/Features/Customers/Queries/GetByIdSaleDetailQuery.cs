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
    public class GetByIdSaleDetailQuery
        : IRequest<IResponseWrapper<SaleDetailResponse>>, IValidateMe
    {
        public Guid Id { get; set; }
    }

    public class GetByIdSaleDetailQueryHandler
        : IRequestHandler<GetByIdSaleDetailQuery, IResponseWrapper<SaleDetailResponse>>
    {
        private readonly ISalesService _salesService;

        public GetByIdSaleDetailQueryHandler(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IResponseWrapper<SaleDetailResponse>> Handle(
            GetByIdSaleDetailQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var saleDetail = await _salesService.GetSaleDetailAsync(request.Id);

                return await ResponseWrapper<SaleDetailResponse>
                    .SuccessAsync(saleDetail, "Sales detail retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<SaleDetailResponse>
                    .FailureAsync(ex.Message, "Failed to get sales details.");
            }
        }
    }

}
