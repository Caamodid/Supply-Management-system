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
    public class DeleteCategoryCommand : IRequest<IResponseWrapper<Guid>>, IValidateMe
    {
        public Guid Id { get; set; }

    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResponseWrapper<Guid>>
    {
        private readonly ICompanyService companyService;
        public DeleteCategoryCommandHandler(ICompanyService _companyService)
        {
            companyService = _companyService;
        }
        public async Task<IResponseWrapper<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedId = await companyService.DeleteCategoryAsync(request.Id);
                return await ResponseWrapper<Guid>.SuccessAsync(deletedId, "Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<Guid>.FailureAsync(ex.Message, "Failed to delete category.");
            }
        }
    }
}
