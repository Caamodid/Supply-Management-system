using Application.Common.Response;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Repository
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public CompanyService(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUser = currentUserService;
        }


        public async Task<Company> CreateCompAsync(Company request)
        {

            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            request.CreatedBy = _currentUser.UserId;
            request.CreatedBy = _currentUser.UserId;
            await _context.Companies.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }



        public async Task<Company> UpdateCompAsync(Guid id, Company request)
        {
            var existingClient = await _context.Companies.FindAsync(id);
            if (existingClient == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            request.CreatedBy = _currentUser.UserId;

            _context.Entry(existingClient).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return existingClient;
        }


        public async Task<Guid> DeleteCompAsync(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }


        public async Task<Company> GetByIdCompAsync(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }


        public async Task<List<CompanyResponses>> GetAllCompAsync()
        {
            var data = await (
                from c in _context.Companies
                join u in _context.Users
                    on c.CreatedBy equals u.Id
                select new CompanyResponses
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    CreatedAt = c.CreatedAt,
                    CreatedBy = u.FirstName,
                    Name = c.Name,
                    Address = c.Address,
                    Phone = c.Phone,
                    LogoUrl = c.LogoUrl
                }
            ).ToListAsync();

            return data;
        }



        public async Task<Branch> CreateBranchAsync(Branch request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            request.CreatedBy = _currentUser.UserId;
            await _context.Branches.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }




        public async Task<Branch> UpdateBranchAsync(Guid id, Branch request)
        {
            var existingBranch = await _context.Branches.FindAsync(id);
            if (existingBranch == null)
            {
                throw new KeyNotFoundException("Branch not found.");
            }
            request.CreatedBy = _currentUser.UserId;

            _context.Entry(existingBranch).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return existingBranch;
        }



        public async Task<Guid> DeleteBranchAsync(Guid id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                throw new KeyNotFoundException("Branch not found.");
            }
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return branch.Id;
        }

        public async Task<Branch> GetByIdBranchAsync(Guid id)
        {
            return await _context.Branches.FindAsync(id);
        }



        public async Task<List<BranchResponses>> GetAllBranchAsync()
        {
            var data = await (
                from c in _context.Companies
                join u in _context.Users
                    on c.CreatedBy equals u.Id
                join  b in _context.Branches
                    on c.Id equals b.CompanyId
                select new BranchResponses
                {
                    Id = b.Id,
                    CompnayName = c.Name,
                    IsActive = c.IsActive,
                    CreatedAt = c.CreatedAt,
                    CreatedBy = u.FirstName,
                    BranchName = b.BranchName,
                    Address = b.Address,
                    Phone = b.Phone,
                }
            ).ToListAsync();

            return data;
        }




        public async Task<Category> CreateCategoryAsync(Category request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            request.CreatedBy = _currentUser.UserId;
            await _context.Categories.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }



        public async Task<Category> UpdateCategoryAsync(Guid id, Category request)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            request.CreatedBy = _currentUser.UserId;

            _context.Entry(existingCategory).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return existingCategory;
        }



        public async Task<Guid> DeleteCategoryAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }



        public async Task<List<CategoryResponses>> GetAlCategoryAsync()
        {
            var data = await (
                from c in _context.Companies
                join u in _context.Users
                    on c.CreatedBy equals u.Id
                join Ca in _context.Categories
                    on c.Id equals Ca.CompanyId
                select new CategoryResponses
                {
                    Id = Ca.Id,
                    Name = Ca.Name,
                    Company=c.Name,
                    Description = Ca.Description,
                    CreatedAt = c.CreatedAt,
                    CreatedBy = u.FirstName,

                }
            ).ToListAsync();

            return data;
        }

        public async Task<Category> GetByIdCategoryAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }


    }
}
