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
    public class CreateOpenProductConversionCommand : IRequest<IResponseWrapper<StockMovementResponse>>, IValidateMe
    {
        public OpenProductConversionRequest  openProductConversion { get; set; } = default!;

    }

    public class CreateOpenProductConversionCommandHandler : IRequestHandler<CreateOpenProductConversionCommand, IResponseWrapper<StockMovementResponse>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public CreateOpenProductConversionCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<StockMovementResponse>> Handle(
       CreateOpenProductConversionCommand request,
       CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Request model
                var convertStockRequest =
                    _mapper.Map<OpenProductConversionRequest>(request.openProductConversion);

                // 2️⃣ Execute stock transfer (NO return value)
                await _productService.OpenProductConversionAsync(convertStockRequest);

                // 3️⃣ Build response manually (summary response)
                var responseDto = new StockMovementResponse
                {
                    MovementType = StockMovementTypes.TransferOut,
                    Reason = $"Transferred to branch"
                };

                // 4️⃣ Return success
                return await ResponseWrapper<StockMovementResponse>
                    .SuccessAsync(responseDto, "Stock convert successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<StockMovementResponse>
                    .FailureAsync(ex.Message, "Failed to convert stock.");
            }
        }


    }

}
