using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Setup.Queries;
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
    public class GetProductQuery : IRequest<IResponseWrapper<List<ProductResp>>>, IValidateMe
    {
    }


    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IResponseWrapper<List<ProductResp>>>
    {
        private readonly IProductService  _productService;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IProductService  productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<ProductResp>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productService.GetProductsAsync();

                var responseDtos = _mapper.Map<List<ProductResp>>(products);

                return await ResponseWrapper<List<ProductResp>>.SuccessAsync(responseDtos, "Products retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<ProductResp>>.FailureAsync(ex.Message, "Failed to get Products list.");
            }
        }
    }

}
