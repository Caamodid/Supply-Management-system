using Application.Common.Response;
using Application.Common.Wrapper;
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
    public class GetByAllGetAllStockTransfersQuery : IRequest<IResponseWrapper<List<StockTransferResponse>>>, IValidateMe
    {
    }

    public class GetByAllGetAllStockTransfersQueryHandler : IRequestHandler<GetByAllGetAllStockTransfersQuery, IResponseWrapper<List<StockTransferResponse>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetByAllGetAllStockTransfersQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<StockTransferResponse>>> Handle(GetByAllGetAllStockTransfersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var stockTransfers = await _productService.GetAllStockTransfersAsync();

                var responseDtos = _mapper.Map<List<StockTransferResponse>>(stockTransfers);

                return await ResponseWrapper<List<StockTransferResponse>>.SuccessAsync(responseDtos, "stock Transfers retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<StockTransferResponse>>.FailureAsync(ex.Message, "Failed to get stock Transfers.");
            }
        }
    }

}
