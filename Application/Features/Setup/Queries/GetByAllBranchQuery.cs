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
    public class GetByAllBranchQuery : IRequest<IResponseWrapper<List<BranchResponses>>>, IValidateMe
    {
    }

    public class GetByAllBranchQueryHandler : IRequestHandler<GetByAllBranchQuery, IResponseWrapper<List<BranchResponses>>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public GetByAllBranchQueryHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<BranchResponses>>> Handle(GetByAllBranchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var branches = await companyService.GetAllBranchAsync();

                var responseDtos = _mapper.Map<List<BranchResponses>>(branches);

                return await ResponseWrapper<List<BranchResponses>>.SuccessAsync(responseDtos, "branches retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<BranchResponses>>.FailureAsync(ex.Message, "Failed to get branches list.");
            }
        }
    }

}
