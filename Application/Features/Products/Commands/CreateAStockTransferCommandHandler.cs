using Application.Common.Helper;
using Application.Common.Request;
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

namespace Application.Features.Products.Commands
{
    public class CreateAStockTransferCommand : IRequest<IResponseWrapper<StockMovementResponse>>, IValidateMe
    {
        public StockTransferRequest  stockTransferRequest { get; set; } = default!;

    }

    public class CreateAStockTransferCommandHandler : IRequestHandler<CreateAStockTransferCommand, IResponseWrapper<StockMovementResponse>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public CreateAStockTransferCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<StockMovementResponse>> Handle(
       CreateAStockTransferCommand request,
       CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Request model
                var transferStockRequest =
                    _mapper.Map<StockTransferRequest>(request.stockTransferRequest);

                // 2️⃣ Execute stock transfer (NO return value)
                await _productService.TransferStockAsync(transferStockRequest);

                // 3️⃣ Build response manually (summary response)
                var responseDto = new StockMovementResponse
                {
                    ProductId = transferStockRequest.ProductId,
                    BranchId = transferStockRequest.FromBranchId,
                    QuantityChange = transferStockRequest.Quantity,
                    MovementType = StockMovementTypes.TransferOut,
                    Reason = $"Transferred to branch {transferStockRequest.ToBranchId}"
                };

                // 4️⃣ Return success
                return await ResponseWrapper<StockMovementResponse>
                    .SuccessAsync(responseDto, "Stock transferred successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<StockMovementResponse>
                    .FailureAsync(ex.Message, "Failed to transfer stock.");
            }
        }


    }

}
