using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Setup.Queries;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class GetByAllStockListQuery : IRequest<IResponseWrapper<List<StockListResponse>>>, IValidateMe
    {
        public Guid? BranchId { get; set; }


    }

    public class GetByAllStockListQueryHandler : IRequestHandler<GetByAllStockListQuery, IResponseWrapper<List<StockListResponse>>>
    {
        private readonly IProductService  _productService;
        private readonly IMapper _mapper;
        public GetByAllStockListQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<StockListResponse>>> Handle(GetByAllStockListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var stockLis = await _productService.GetStockListAsync(request.BranchId);

                var responseDtos = _mapper.Map<List<StockListResponse>>(stockLis);

                return await ResponseWrapper<List<StockListResponse>>.SuccessAsync(responseDtos, "stockLis retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<StockListResponse>>.FailureAsync(ex.Message, "Failed to get stock list.");
            }
        }
    }

}
