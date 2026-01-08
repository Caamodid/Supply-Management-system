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
    public class GetByIdCompanyQuery : IRequest<IResponseWrapper<CompanyResponses>>, IValidateMe
    {
        public Guid Id { get; set; }
    }

    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, IResponseWrapper<CompanyResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public GetByIdCompanyQueryHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<CompanyResponses>> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await companyService.GetByIdCompAsync(request.Id);

                if (company == null)
                    return await ResponseWrapper<CompanyResponses>.FailureAsync("Company not found.", "No company with this ID.");

                var responseDto = _mapper.Map<CompanyResponses>(company);

                return await ResponseWrapper<CompanyResponses>.SuccessAsync(responseDto, "Company retrieves successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CompanyResponses>.FailureAsync(ex.Message, "Failed to retrieve Company.");
            }
        }
    }

}
