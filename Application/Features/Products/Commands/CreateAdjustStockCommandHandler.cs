using Application.Common.Helper;
using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class CreateAdjustStockCommand  : IRequest<IResponseWrapper<StockMovementResponse>>, IValidateMe
    {
        public StockAdjustmentRequest  stockAdjustment { get; set; } = default!;

    }

    public class CreateAdjustStockCommandHandler : IRequestHandler<CreateAdjustStockCommand, IResponseWrapper<StockMovementResponse>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public CreateAdjustStockCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<StockMovementResponse>> Handle(
            CreateAdjustStockCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Request model
                var stockAdjustmentRequest =
                    _mapper.Map<StockAdjustmentRequest>(request.stockAdjustment);

                // 2️⃣ Execute adjustment (NO return value)
                await _productService.AdjustStockAsync(stockAdjustmentRequest);

                // 3️⃣ Build response manually (or query later if needed)
                var responseDto = new StockMovementResponse
                {
                    ProductId = stockAdjustmentRequest.ProductId,
                    BranchId = stockAdjustmentRequest.BranchId,
                    QuantityChange = stockAdjustmentRequest.NewQuantity,
                    MovementType = StockMovementTypes.Adjustment,
                    Reason = stockAdjustmentRequest.Reason
                };

                // 4️⃣ Return success
                return await ResponseWrapper<StockMovementResponse>
                    .SuccessAsync(responseDto, "Stock adjusted successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<StockMovementResponse>
                    .FailureAsync(ex.Message, "Failed to adjust stock.");
            }
        }
    }

}
