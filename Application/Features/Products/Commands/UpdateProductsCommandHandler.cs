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
    public class UpdateProductsCommand: IRequest<IResponseWrapper<ProductResponses>>, IValidateMe
    {
        public Guid Id { get; set; }
        public UpdateProductRequest UpdateProduct { get; set; } = default!;
    }



    public class UpdateProductsCommandHandler
        : IRequestHandler<UpdateProductsCommand, IResponseWrapper<ProductResponses>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public UpdateProductsCommandHandler(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<ProductResponses>> Handle(
            UpdateProductsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map DTO → Product entity
                var productEntity = _mapper.Map<Product>(request.UpdateProduct);

                // 2️⃣ Update Product + Inventory (ONE service call)
                var updatedProduct = await _productService.UpdateProductWithInventoryAsync(
                    request.Id,
                    productEntity,
                    request.UpdateProduct.BranchId,
                    request.UpdateProduct.Quantity,
                    request.UpdateProduct.MinStockLevel
                );

                // 3️⃣ Map updated entity → Response DTO
                var responseDto = _mapper.Map<ProductResponses>(updatedProduct);

                // 4️⃣ Return success
                return await ResponseWrapper<ProductResponses>
                    .SuccessAsync(responseDto, "Product updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<ProductResponses>
                    .FailureAsync(ex.Message, "Failed to update product.");
            }
        }
    }

}