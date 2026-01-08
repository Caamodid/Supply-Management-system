using Application.Common.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
 public interface ICompanyService
    {
        Task<Company> CreateCompAsync(Company request);
        Task<Company> UpdateCompAsync(Guid Id , Company request);
        Task<Guid> DeleteCompAsync(Guid Id);
        Task<Company?> GetByIdCompAsync(Guid Id);
        Task<List<CompanyResponses>> GetAllCompAsync();



        Task<Branch> CreateBranchAsync(Branch request);
        Task<Branch> UpdateBranchAsync(Guid Id, Branch request);
        Task<Guid> DeleteBranchAsync(Guid Id);
        Task<Branch?> GetByIdBranchAsync(Guid Id);
        Task<List<BranchResponses?>> GetAllBranchAsync();



        Task<Category> CreateCategoryAsync(Category request);
        Task<Category> UpdateCategoryAsync(Guid Id, Category request);
        Task<Guid> DeleteCategoryAsync(Guid Id);
        Task<Category?> GetByIdCategoryAsync(Guid Id);
        Task<List<CategoryResponses?>> GetAlCategoryAsync();
    }
}
