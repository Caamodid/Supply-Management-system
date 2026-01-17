using Application.Common.Helper;
using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Products.Commands;
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

namespace Application.Features.Customers.Commands
{
    public class CreateSalesCommand : IRequest<IResponseWrapper<SalesResponses>>, IValidateMe
    {
        public CreateSalesAndSaleItemRequest  CreateSalesAndSaleItemRequest { get; set; } = default!;

    }
    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommand, IResponseWrapper<SalesResponses>>
    {
        private readonly ISalesService  _salesService;
        private readonly IMapper _mapper;
        public CreateSalesCommandHandler(ISalesService  salesService, IMapper mapper)
        {
            _mapper = mapper;
            _salesService = salesService;
        }
        public async Task<IResponseWrapper<SalesResponses>> Handle(
            CreateSalesCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Request model
                var salesRequest =
                    _mapper.Map<CreateSalesAndSaleItemRequest>(request.CreateSalesAndSaleItemRequest);

                // 2️⃣ Execute adjustment (NO return value)
                await _salesService.CreateSaleWithItemsAsync(salesRequest);

                // 3️⃣ Build response manually (or query later if needed)
                var responseDto = new SalesResponses
                {
                    PaymentStatus = "Closed"

                };

                // 4️⃣ Return success
                return await ResponseWrapper<SalesResponses>
                    .SuccessAsync(responseDto, "Sales created successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<SalesResponses>
                    .FailureAsync(ex.Message, "failed to create sales.");
            }
        }
    }



}
