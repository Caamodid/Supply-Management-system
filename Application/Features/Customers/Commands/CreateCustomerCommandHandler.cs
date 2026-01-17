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
    public class CreateCustomerCommand : IRequest<IResponseWrapper<CustomerResponses>>, IValidateMe
    {
        public CreateCustomerRequest  CreateCustomerRequest { get; set; } = default!;

    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, IResponseWrapper<CustomerResponses>>
    {
        private readonly ICustomerService  _customerService;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerService  customerService, IMapper mapper)
        {
            _mapper = mapper;
            _customerService = customerService;
        }
        public async Task<IResponseWrapper<CustomerResponses>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Entity
                var customerEntity = _mapper.Map<Customer>(request.CreateCustomerRequest);
                // 2️⃣ Save entity
                var createdCustomer = await _customerService.CreateCustomAsync(customerEntity);
                // 3️⃣ Map back Entity → Response DTO
                var responseDto = _mapper.Map<CustomerResponses>(createdCustomer);
                // 4️⃣ Return standardized success response
                return await ResponseWrapper<CustomerResponses>.SuccessAsync(responseDto, "Customer created successfully.");
            }
            catch (Exception ex)
            {
                // 5️⃣ Handle and wrap any unexpected error
                return await ResponseWrapper<CustomerResponses>.FailureAsync(ex.Message, "Failed to create Customer.");
            }
        }
    }

}
