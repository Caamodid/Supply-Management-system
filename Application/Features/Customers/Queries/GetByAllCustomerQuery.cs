using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries
{
    public class GetByAllCustomerQuery :IRequest<IResponseWrapper<List<CustomerResponses>>>, IValidateMe  
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Phone { get; set; }
    }
    public class GetByAllCustomerQueryHandler
        : IRequestHandler<GetByAllCustomerQuery, IResponseWrapper<List<CustomerResponses>>>
    {
        private readonly ICustomerService _customerService;

        public GetByAllCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IResponseWrapper<List<CustomerResponses>>> Handle(
            GetByAllCustomerQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerService.GetAllCustomAsync(
                    request.FromDate,
                    request.ToDate,
                    request.Phone
                );

                return await ResponseWrapper<List<CustomerResponses>>
                    .SuccessAsync(customers, "Customers retrieved successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<CustomerResponses>>
                    .FailureAsync(ex.Message, "Failed to get Customers list.");
            }
        }
    }
}

