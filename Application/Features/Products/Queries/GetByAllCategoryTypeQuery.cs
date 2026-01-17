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
    public class GetByAllCategoryTypeQuery : IRequest<IResponseWrapper<List<CategoryTypeResponses>>>, IValidateMe
    {
    }

    public class GetByAllCategoryTypeQueryHandler : IRequestHandler<GetByAllCategoryTypeQuery, IResponseWrapper<List<CategoryTypeResponses>>>
    {
        private readonly IProductService  productService;
        private readonly IMapper _mapper;
        public GetByAllCategoryTypeQueryHandler(IProductService _productService, IMapper mapper)
        {
            productService = _productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<CategoryTypeResponses>>> Handle(GetByAllCategoryTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Categorytype = await productService.GetAllCategoryTypeAsync();

                var responseDtos = _mapper.Map<List<CategoryTypeResponses>>(Categorytype);

                return await ResponseWrapper<List<CategoryTypeResponses>>.SuccessAsync(responseDtos, "Category type retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<CategoryTypeResponses>>.FailureAsync(ex.Message, "Failed to get Category type list.");
            }
        }
    }

}
