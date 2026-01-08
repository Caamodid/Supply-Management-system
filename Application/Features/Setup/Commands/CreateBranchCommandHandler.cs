using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setup.Commands
{
    public class CreateBranchCommand : IRequest<IResponseWrapper<BranchResponses>>, IValidateMe
    {

        public CreateBranchRequest  createBranchRequest { get; set; } = default!;

    }

    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, IResponseWrapper<BranchResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public CreateBranchCommandHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<BranchResponses>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Entity
                var branchEntity = _mapper.Map<Branch>(request.createBranchRequest);
                // 2️⃣ Save entity
                var createdBranch = await companyService.CreateBranchAsync(branchEntity);
                // 3️⃣ Map back Entity → Response DTO
                var responseDto = _mapper.Map<BranchResponses>(createdBranch);
                // 4️⃣ Return standardized success response
                return await ResponseWrapper<BranchResponses>.SuccessAsync(responseDto, "Branch created successfully.");
            }
            catch (Exception ex)
            {
                // 5️⃣ Handle and wrap any unexpected error
                return await ResponseWrapper<BranchResponses>.FailureAsync(ex.Message, "Failed to create Branch.");
            }
        }
    }


}
