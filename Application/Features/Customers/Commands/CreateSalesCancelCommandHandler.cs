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

namespace Application.Features.Customers.Commands
{
    public class CreateSalesCancelCommand : IRequest<IResponseWrapper<SalesResponses>>, IValidateMe
    {
        public CancelSaleRequest  cancelSaleRequest { get; set; } = default!;

    }

    public class CreateSalesCancelCommandHandler : IRequestHandler<CreateSalesCancelCommand, IResponseWrapper<SalesResponses>>
    {
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper;
        public CreateSalesCancelCommandHandler(ISalesService salesService, IMapper mapper)
        {
            _mapper = mapper;
            _salesService = salesService;
        }
        public async Task<IResponseWrapper<SalesResponses>> Handle(
            CreateSalesCancelCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Request model
                var salesRequest =
                    _mapper.Map<CancelSaleRequest>(request.cancelSaleRequest);

                // 2️⃣ Execute adjustment (NO return value)
                await _salesService.CancelSaleAsync(salesRequest);

                // 3️⃣ Build response manually (or query later if needed)
                var responseDto = new SalesResponses
                {
                    PaymentStatus = "Cancelled"

                };

                // 4️⃣ Return success
                return await ResponseWrapper<SalesResponses>
                    .SuccessAsync(responseDto, "Sales Cancelled successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<SalesResponses>
                    .FailureAsync(ex.Message, "failed to Cancel sales.");
            }
        }
    }
}
