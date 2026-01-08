using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employees> AddAsync(Employees employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employees> GetByIdAsync(Guid id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
           
        }

        public async Task<Employees> UpdateAsync(Employees employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Guid> DeleteAsync(Employees employees)
        {
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return employees.Id;
        }
    }
}
