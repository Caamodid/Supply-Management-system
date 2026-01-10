using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Setup.Commands;
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
    public class CreateProductsCommand :IRequest<IResponseWrapper<ProductResponses>>, IValidateMe
    {
        public CreateProductRequest   createProduct  { get; set; } = default!;

    }

    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, IResponseWrapper<ProductResponses>>
    {
        private readonly IProductService  _productService;
        private readonly IMapper _mapper;
        public CreateProductsCommandHandler(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public async Task<IResponseWrapper<ProductResponses>> Handle(
            CreateProductsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map DTO → Product entity
                var productEntity = _mapper.Map<Product>(request.createProduct);

                // 2️⃣ Call ONE service method (transaction inside)
                var createdProduct = await _productService.CreateProductWithInventoryAsync(
                    productEntity,
                    request.createProduct.BranchId,
                    request.createProduct.Quantity,
                    request.createProduct.MinStockLevel
                );

                // 3️⃣ Map Entity → Response
                var responseDto = _mapper.Map<ProductResponses>(createdProduct);

                // 4️⃣ Return success
                return await ResponseWrapper<ProductResponses>
                    .SuccessAsync(responseDto, "Product created successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<ProductResponses>
                    .FailureAsync(ex.Message, "Failed to create Product.");
            }
        }
    }

}
