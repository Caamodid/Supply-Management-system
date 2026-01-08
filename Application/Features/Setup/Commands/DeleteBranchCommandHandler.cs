using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setup.Commands
{
    public class DeleteBranchCommand : IRequest<IResponseWrapper<Guid>>, IValidateMe
    {
        public Guid Id { get; set; }

    }

    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, IResponseWrapper<Guid>>
    {
        private readonly ICompanyService companyService;

        public DeleteBranchCommandHandler(ICompanyService _companyService)
        {
            companyService = _companyService;

        }

        public async Task<IResponseWrapper<Guid>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedId = await companyService.DeleteBranchAsync(request.Id);
                return await ResponseWrapper<Guid>.SuccessAsync(deletedId, "Branch deleted successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<Guid>.FailureAsync(ex.Message, "Failed to delete branch.");
            }
        }
    }

}
