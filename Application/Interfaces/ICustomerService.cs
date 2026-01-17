using Application.Common.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomAsync(Customer request);
        Task<Customer> UpdateCustomAsync(Guid Id, Customer request);
        Task<Guid> DeleteCustomAsync(Guid Id);
        Task<List<CustomerResponses>> GetAllCustomAsync(
      DateTime? fromDate,
      DateTime? toDate,
      string? phone
  );

    }
}
