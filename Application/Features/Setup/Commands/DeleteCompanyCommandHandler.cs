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

namespace Application.Features.Setup.Commands
{
    public class DeleteCompanyCommand : IRequest<IResponseWrapper<Guid>>, IValidateMe
    {
        public Guid Id { get; set; }
    }
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, IResponseWrapper<Guid>>
    {
        private readonly ICompanyService companyService;

        public DeleteCompanyCommandHandler(ICompanyService _companyService)
        {
            companyService = _companyService;

        }

        public async Task<IResponseWrapper<Guid>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedId = await companyService.DeleteCompAsync(request.Id);
                return await ResponseWrapper<Guid>.SuccessAsync(deletedId, "Company deleted successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<Guid>.FailureAsync(ex.Message, "Fauled to delete Company.");
            }
        }
    }

}
