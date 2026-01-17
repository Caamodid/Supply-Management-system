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
    public class GetByAllGetAllProductWithCategoryAndWithCategoryTypeQuery : IRequest<IResponseWrapper<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>>, IValidateMe
    {
    }


    public class GetByAllGetAllProductWithCategoryAndWithCategoryTypeQueryHandler : IRequestHandler<GetByAllGetAllProductWithCategoryAndWithCategoryTypeQuery, IResponseWrapper<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetByAllGetAllProductWithCategoryAndWithCategoryTypeQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>> Handle(GetByAllGetAllProductWithCategoryAndWithCategoryTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var stockTransfers = await _productService.ProductWithCategoryAndWithCategoryTypeAsync();

                var responseDtos = _mapper.Map<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>(stockTransfers);

                return await ResponseWrapper<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>.SuccessAsync(responseDtos, "stock Transfers retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>.FailureAsync(ex.Message, "Failed to get stock Transfers.");
            }
        }
    }
}
