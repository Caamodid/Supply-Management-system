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
    public class GetByIdBranchQuery : IRequest<IResponseWrapper<BranchResponses>>, IValidateMe
    {
        public Guid Id { get; set; }

    }

    public class GetByIdBranchQueryHandler : IRequestHandler<GetByIdBranchQuery, IResponseWrapper<BranchResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public GetByIdBranchQueryHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<BranchResponses>> Handle(GetByIdBranchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = await companyService.GetByIdBranchAsync(request.Id);
                if (branch == null)
                    return await ResponseWrapper<BranchResponses>.FailureAsync("Branch not found.", "No branch with this ID.");
                var responseDto = _mapper.Map<BranchResponses>(branch);
                return await ResponseWrapper<BranchResponses>.SuccessAsync(responseDto, "Branch retrieves successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<BranchResponses>.FailureAsync(ex.Message, "Failed to retrieve Branch.");
            }
        }
    }
}
