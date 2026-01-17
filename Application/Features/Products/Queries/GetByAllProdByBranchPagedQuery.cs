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
    public class GetByAllProdByBranchPagedQuery
      : IRequest<IResponseWrapper<PagedResponse<ProductResponses>>>, IValidateMe
    {
        public Guid BranchId { get; set; }
    }

    public class GetByAllProdByBranchPagedQueryHandler
        : IRequestHandler<GetByAllProdByBranchPagedQuery, IResponseWrapper<PagedResponse<ProductResponses>>>
    {
        private readonly IProductService _productService;

        public GetByAllProdByBranchPagedQueryHandler(
            IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IResponseWrapper<PagedResponse<ProductResponses>>> Handle(
            GetByAllProdByBranchPagedQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Get ALL products for branch
                var list = await _productService
                    .GetAllProductsAsync();

                // 2️⃣ Wrap list into PagedResponse
                var pagedResult = new PagedResponse<ProductResponses>
                {
                    Items = list,
                    TotalCount = list.Count,
                    Page = 1,
                    PageSize = list.Count
                };

                // 3️⃣ Return success
                return await ResponseWrapper<PagedResponse<ProductResponses>>
                    .SuccessAsync(pagedResult, "Product list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<PagedResponse<ProductResponses>>
                    .FailureAsync(ex.Message, "Failed to get product list.");
            }
        }
    }
}
