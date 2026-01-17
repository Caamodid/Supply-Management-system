using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Setup.Commands;
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

namespace Application.Features.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<IResponseWrapper<CustomerResponses>>, IValidateMe
    {
        public Guid Id { get; set; }
        public UpdateCustomerRequest   updateCustomer { get; set; } = default!;
    }


    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, IResponseWrapper<CustomerResponses>>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(ICustomerService customerService, IMapper mapper)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        public async Task<IResponseWrapper<CustomerResponses>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map DTO to Entity
                var customerEntity = _mapper.Map<Customer>(request.updateCustomer);

                // Update entity
                var updatedCustomer = await _customerService.UpdateCustomAsync(request.Id, customerEntity);

                // Map updated entity to response
                var responseDto = _mapper.Map<CustomerResponses>(updatedCustomer);

                return await ResponseWrapper<CustomerResponses>.SuccessAsync(responseDto, "Customer updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CustomerResponses>.FailureAsync(ex.Message, "Failed to update Customer.");
            }
        }
    }




}
