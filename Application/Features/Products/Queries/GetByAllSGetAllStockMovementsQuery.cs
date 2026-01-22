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
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
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
                // Get fromDate and toDate, and default to today if null
                DateTime? fromDate = request.fromDate ?? DateTime.UtcNow.Date;
                DateTime? toDate = request.toDate ?? DateTime.UtcNow.Date.AddDays(1).AddTicks(-1); // End of today (11:59:59 PM)

                // Pass dates to the service method
                var stockMovements = await _productService.GetAllStockMovementsAsync(fromDate, toDate);

                var responseDtos = _mapper.Map<List<StockMovementResponse>>(stockMovements);

                return await ResponseWrapper<List<StockMovementResponse>>.SuccessAsync(responseDtos, "Stock movements retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<StockMovementResponse>>.FailureAsync(ex.Message, "Failed to get stock movements.");
            }
        }
    }
}
