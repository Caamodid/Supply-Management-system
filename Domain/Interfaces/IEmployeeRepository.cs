using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employees> GetByIdAsync(Guid id);
        Task<List<Employees>> GetAllAsync();
        Task<Employees> AddAsync(Employees employee);
        Task <Employees> UpdateAsync(Employees employee);
        Task<Guid> DeleteAsync(Employees  employees);
    }
}
