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
    public class GetByAllSGetAllStockMovementsQuery : IRequest<IResponseWrapper<List<StockMovementResponse>>>, IValidateMe
    {

    }

    public class GetByAllSGetAllStockMovementsQueryHandler : IRequestHandler<GetByAllSGetAllStockMovementsQuery, IResponseWrapper<List<StockMovementResponse>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetByAllSGetAllStockMovementsQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<StockMovementResponse>>> Handle(GetByAllSGetAllStockMovementsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var stockMovements = await _productService.GetAllStockMovementsAsync();

                var responseDtos = _mapper.Map<List<StockMovementResponse>>(stockMovements);

                return await ResponseWrapper<List<StockMovementResponse>>.SuccessAsync(responseDtos, "stockMovements retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<StockMovementResponse>>.FailureAsync(ex.Message, "Failed to get stockMovements.");
            }
        }
    }

}
