using Application.Common.Wrapper;
using Application.Features.Setup.Commands;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<IResponseWrapper<Guid>>, IValidateMe
    {
        public Guid Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, IResponseWrapper<Guid>>
    {
        private readonly ICustomerService _customerService;
     
        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IResponseWrapper<Guid>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedId = await _customerService.DeleteCustomAsync(request.Id);
                return await ResponseWrapper<Guid>.SuccessAsync(deletedId, "Customet deleted successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<Guid>.FailureAsync(ex.Message, "Customet to delete branch.");
            }
        }
    }

}
