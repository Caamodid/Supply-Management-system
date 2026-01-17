using Application.Common.Response;
using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public CustomerService(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUser = currentUserService;
        }

        public async Task<Domain.Entities.Customer> CreateCustomAsync(Domain.Entities.Customer request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");
            request.CreatedBy = _currentUser.UserId;
            await _context.Customers.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }


        public async Task<Domain.Entities.Customer> UpdateCustomAsync(Guid id, Domain.Entities.Customer request)
        {
            var existingClient = await _context.Customers.FindAsync(id);
            if (existingClient == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");


            existingClient.UpdatedBy = _currentUser.UserId;
            existingClient.Name = request.Name;
            existingClient.Email = request.Email;
            existingClient.Phone = request.Phone;
            existingClient.CustomerType = request.CustomerType;
            existingClient.Address = request.Address;
            existingClient.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return existingClient;
        }





        public async Task<Guid> DeleteCustomAsync(Guid id)
        {
            var existingClient = await _context.Customers.FindAsync(id);
            if (existingClient == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            _context.Customers.Remove(existingClient);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<CustomerResponses>> GetAllCustomAsync(
            DateTime? fromDate,
            DateTime? toDate,
            string? phone
        )
        {
            var todayUtc = DateTime.UtcNow.Date;

            var startDate = (fromDate?.ToUniversalTime())
                ?? new DateTime(todayUtc.Year, todayUtc.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var endDate = (toDate?.ToUniversalTime())
                ?? startDate.AddMonths(1).AddDays(-1).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var query =
                from c in _context.Customers.AsNoTracking()
                join u in _context.Users.AsNoTracking()
                    on c.CreatedBy equals u.Id
                join b in _context.Branches.AsNoTracking() // join Branches table
                    on c.BranchId equals b.Id
                where
                    c.CreatedAt >= startDate &&
                    c.CreatedAt <= endDate &&
                    (string.IsNullOrEmpty(phone) || c.Phone.Contains(phone))
                select new CustomerResponses
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    CreatedBy = u.FirstName,
                    UpdatedBy = u.FirstName,
                    CustomerType = c.CustomerType,
                    Branch = b.BranchName,  // Add branch name
                    BranchId = b.Id     // Add branch ID
                };

            return await query.ToListAsync();
        }

    }
}