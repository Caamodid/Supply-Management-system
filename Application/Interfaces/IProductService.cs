using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        // =======================
        // PRODUCT + INVENTORY
        // =======================
        Task<Product> CreateProductWithInventoryAsync(
            Product product,
            Guid branchId,
            decimal quantity,
            decimal minStockLevel);

        Task<Product> UpdateProductWithInventoryAsync(
            Guid productId,
            Product product,
            Guid branchId,
            decimal quantity,
            decimal minStockLevel);

        Task<Guid> DeleteProdAsync(Guid id);
        Task<Product?> GetByIdProdAsync(Guid id);

        Task<List<Product>> GetProductsAsync();



        Task<List<ProductResponses>> GetAllProductsAsync();



        Task<List<ProductQntyResponses>> GetAllProductsQntyAsync();

        // =======================
        // CATEGORY TYPES
        // =======================
        Task<CategoryType> CreateCategoryTypeAsync(CategoryType request);
        Task<CategoryType> UpdateCategoryTypeAsync(Guid id, CategoryType request);
        Task<Guid> DeleteCategoryTypeAsync(Guid id);
        Task<List<CategoryTypeResponses>> GetAllCategoryTypeAsync();

        // =======================
        // STOCK OPERATIONS
        // =======================
        Task ReceiveStockAsync(ReceiveStockRequest request);
        Task TransferStockAsync(StockTransferRequest request);
        Task AdjustStockAsync(StockAdjustmentRequest request);
        Task OpenProductConversionAsync(OpenProductConversionRequest request);

  

        // =======================
        // STOCK QUERIES
        // =======================
        Task<List<StockListResponse>> GetStockListAsync(Guid? branchId = null);
        Task<List<StockMovementResponse>> GetAllStockMovementsAsync();
        Task<List<StockTransferResponse>> GetAllStockTransfersAsync();
        Task<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>> ProductWithCategoryAndWithCategoryTypeAsync();
    }
}
