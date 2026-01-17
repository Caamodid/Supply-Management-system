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
    public class CreateReceiveStockCommand : IRequest<IResponseWrapper<StockMovementResponse>>, IValidateMe
    {
        public ReceiveStockRequest  receiveStockRequest { get; set; } = default!;


    }

    public class CreateReceiveStockCommandHandler : IRequestHandler<CreateReceiveStockCommand, IResponseWrapper<StockMovementResponse>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public CreateReceiveStockCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<StockMovementResponse>> Handle(
      CreateReceiveStockCommand request,
      CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Request model
                var receiveStockRequest =
                    _mapper.Map<ReceiveStockRequest>(request.receiveStockRequest);

                // 2️⃣ Execute receive stock (NO return value)
                await _productService.ReceiveStockAsync(receiveStockRequest);

                // 3️⃣ Build response manually
                var responseDto = new StockMovementResponse
                {
                    ProductId = receiveStockRequest.ProductId,
                    BranchId = receiveStockRequest.BranchId,
                    QuantityChange = receiveStockRequest.Quantity,
                    MovementType = StockMovementTypes.Receive,
                    Reason = "Stock received"
                };

                // 4️⃣ Return success
                return await ResponseWrapper<StockMovementResponse>
                    .SuccessAsync(responseDto, "Stock received successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<StockMovementResponse>
                    .FailureAsync(ex.Message, "Failed to receive stock.");
            }
        }

    }

}
