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
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setup.Commands
{
    public class UpdateBranchCommand : IRequest<IResponseWrapper<BranchResponses>>, IValidateMe
    {
        public Guid Id { get; set; }
        public UpdateBranchRequest  updateBranch { get; set; } = default!;
    }
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, IResponseWrapper<BranchResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public UpdateBranchCommandHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<BranchResponses>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map DTO to Entity
                var branchEntity = _mapper.Map<Branch>(request.updateBranch);

                // Update entity
                var updatedbranch = await companyService.UpdateBranchAsync(request.Id, branchEntity);

                // Map updated entity to response
                var responseDto = _mapper.Map<BranchResponses>(updatedbranch);

                return await ResponseWrapper<BranchResponses>.SuccessAsync(responseDto, "Branch updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<BranchResponses>.FailureAsync(ex.Message, "Failed to update branch.");
            }
        }
    }

}
