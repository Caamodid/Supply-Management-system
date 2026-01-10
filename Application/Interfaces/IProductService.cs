using Application.Common.Response;
using Application.Common.Wrapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {


        Task<Product> CreateProductWithInventoryAsync( Product product,Guid branchId,decimal quantity,decimal minStockLevel);
        Task<Product> UpdateProductWithInventoryAsync( Guid productId,Product product,Guid branchId,decimal quantity,decimal minStockLevel);
        Task<Guid> DeleteProdAsync(Guid Id);
        Task<Product?> GetByIdProdAsync(Guid Id);
        Task<PagedResponse<ProductResponses>> GetAllProdByBranchPagedAsync(Guid branchId, int page = 1, int pageSize = 10);


        Task<CategoryType> CreateCategoryTypeAsync(CategoryType request);
        Task<CategoryType> UpdateCategoryTypeAsync(Guid Id, CategoryType request);
        Task<Guid> DeleteCategoryTypeAsync(Guid Id);
        //Task<CategoryType?> GetByIdCategoryTypeAsync(Guid Id);
        Task<List<CategoryTypeResponses>> GetAllCategoryTypeAsync();







    }
}
