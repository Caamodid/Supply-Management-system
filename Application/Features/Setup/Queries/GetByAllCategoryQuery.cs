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

namespace Application.Features.Setup.Queries
{
    public class GetByAllCategoryQuery : IRequest<IResponseWrapper<List<CategoryResponses>>>, IValidateMe
    {

    }
    public class GetByAllCategoryQueryHandler : IRequestHandler<GetByAllCategoryQuery, IResponseWrapper<List<CategoryResponses>>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public GetByAllCategoryQueryHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<CategoryResponses>>> Handle(GetByAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await companyService.GetAlCategoryAsync();

                var responseDtos = _mapper.Map<List<CategoryResponses>>(categories);

                return await ResponseWrapper<List<CategoryResponses>>.SuccessAsync(responseDtos, "categories retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<CategoryResponses>>.FailureAsync(ex.Message, "Failed to get categories list.");
            }
        }
    }

}
