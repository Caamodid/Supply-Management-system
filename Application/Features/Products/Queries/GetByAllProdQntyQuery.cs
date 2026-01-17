using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class GetByAllProdQntyQuery
     : IRequest<IResponseWrapper<List<ProductQntyResponses>>>, IValidateMe
    {
    }


    public class GetByAllProdQntyQueryHandler
        : IRequestHandler<GetByAllProdQntyQuery, IResponseWrapper<List<ProductQntyResponses>>>
    {
        private readonly IProductService _productService;

        public GetByAllProdQntyQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IResponseWrapper<List<ProductQntyResponses>>> Handle(
            GetByAllProdQntyQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Get ALL products
                var products = await _productService.GetAllProductsQntyAsync();

                // 2️⃣ Return success
                return await ResponseWrapper<List<ProductQntyResponses>>
                    .SuccessAsync(products, "Product list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<ProductQntyResponses>>
                    .FailureAsync(ex.Message, "Failed to get product list.");
            }
        }
    }

}
