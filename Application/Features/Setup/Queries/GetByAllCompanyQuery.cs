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
    public class GetByAllCompanyQuery : IRequest<IResponseWrapper<List<CompanyResponses>>>, IValidateMe
    {

    }

    public class GetByAllCompanyQueryHandler : IRequestHandler<GetByAllCompanyQuery, IResponseWrapper<List<CompanyResponses>>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public GetByAllCompanyQueryHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<CompanyResponses>>> Handle(GetByAllCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var companies = await companyService.GetAllCompAsync();

                var responseDtos = _mapper.Map<List<CompanyResponses>>(companies);

                return await ResponseWrapper<List<CompanyResponses>>.SuccessAsync(responseDtos, "companies retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<CompanyResponses>>.FailureAsync(ex.Message, "Failed to get companies list.");
            }
        }
    }

}
