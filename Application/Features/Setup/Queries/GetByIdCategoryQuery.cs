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
    public class GetByIdCategoryQuery : IRequest<IResponseWrapper<CategoryResponses>>, IValidateMe
    {
        public Guid Id { get; set; }

    }

    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, IResponseWrapper<CategoryResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public GetByIdCategoryQueryHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<CategoryResponses>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await companyService.GetByIdCategoryAsync(request.Id);

                if (category == null)
                    return await ResponseWrapper<CategoryResponses>.FailureAsync("category not found.", "No category with this ID.");

                var responseDto = _mapper.Map<CategoryResponses>(category);

                return await ResponseWrapper<CategoryResponses>.SuccessAsync(responseDto, "Company retrieves successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CategoryResponses>.FailureAsync(ex.Message, "Failed to retrieve category.");
            }
        }
    }



}
