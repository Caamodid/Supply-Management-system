using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public ProductService(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUser = currentUserService;
        }

        public async Task<Product> CreateProductWithInventoryAsync( Product product,Guid branchId,decimal quantity,decimal minStockLevel)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1️⃣ Create Product
                product.CreatedBy = _currentUser.UserId;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                // 2️⃣ Create Inventory
                var inventory = new Inventory
                {
                    ProductId = product.Id,
                    BranchId = branchId,
                    Quantity = quantity,
                    MinStockLevel = minStockLevel,
                    CreatedBy = _currentUser.UserId
                };

                await _context.Inventories.AddAsync(inventory);
                await _context.SaveChangesAsync();

                // 3️⃣ Commit transaction
                await transaction.CommitAsync();

                return product;
            }
            catch
            {
                // 4️⃣ Rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<Product> UpdateProductWithInventoryAsync(
       Guid productId,
       Product request,
       Guid branchId,
       decimal quantity,
       decimal minStockLevel)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1️⃣ Get existing product
                var existingProduct = await _context.Products.FindAsync(productId);
                if (existingProduct == null)
                    throw new KeyNotFoundException("Product not found.");

                // 2️⃣ Update product fields (DO NOT touch CreatedBy / CreatedAt)
                existingProduct.Name = request.Name;
                existingProduct.CategoryId = request.CategoryId;
                existingProduct.CategoryTypeId = request.CategoryTypeId;
                existingProduct.Unit = request.Unit;
                existingProduct.CostPrice = request.CostPrice;
                existingProduct.SellPrice = request.SellPrice;
                existingProduct.WholesalePrice = request.WholesalePrice;
                existingProduct.UpdatedAt = DateTime.UtcNow;
                existingProduct.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();

                // 3️⃣ Get inventory for this branch
                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == productId &&
                        x.BranchId == branchId);

                if (inventory == null)
                    throw new KeyNotFoundException("Inventory not found for this branch.");

                // 4️⃣ Update inventory
                inventory.Quantity = quantity;
                inventory.MinStockLevel = minStockLevel;
                inventory.UpdatedAt = DateTime.UtcNow;
                inventory.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();

                // 5️⃣ Commit transaction
                await transaction.CommitAsync();

                return existingProduct;
            }
            catch
            {
                // 6️⃣ Rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<Guid> DeleteProdAsync(Guid id)
        {
            var company = await _context.Products.FindAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            _context.Products.Remove(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }

        public async Task<Product> GetByIdProdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }






        public async Task<PagedResponse<ProductResponses>> GetAllProdByBranchPagedAsync(
      Guid branchId,
      int page = 1,
      int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var query =
                from p in _context.Products.AsNoTracking()

                    //  Branch (defines which branch we are viewing)
                join b in _context.Branches
                    on branchId equals b.Id

                //  Category
                join cat in _context.Categories
                    on p.CategoryId equals cat.Id

                //  User (CreatedBy)
                join u in _context.Users
                    on p.CreatedBy equals u.Id

                //  Optional CategoryType
                join ct in _context.CategoryTypes
                    on p.CategoryTypeId equals ct.Id into ctGroup
                from ct in ctGroup.DefaultIfEmpty()

                    //  Inventory filtered by branch
                join i in _context.Inventories
                        .Where(x => x.BranchId == branchId)
                    on p.Id equals i.ProductId into invGroup
                from i in invGroup.DefaultIfEmpty()

                select new ProductResponses
                {
                    Id = p.Id,
                    BranchName = b.BranchName,
                    CategoryName = cat.Name,
                    CategoryTypeName = ct != null ? ct.Name : null,

                    Name = p.Name,
                    Description = p.Description,
                    Unit = p.Unit,

                    CostPrice = p.CostPrice,
                    SellPrice = p.SellPrice,
                    WholesalePrice = p.WholesalePrice,

                    Quantity = i != null ? i.Quantity : 0,
                    MinStockLevel = i != null ? i.MinStockLevel : 0,

                    CreatedBy = u.FirstName,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<ProductResponses>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                Items = items
            };
        }



        public async Task<CategoryType> CreateCategoryTypeAsync(CategoryType request)
        {

            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");
            request.CreatedBy = _currentUser.UserId;
            await _context.CategoryTypes.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }


        public async Task<CategoryType> UpdateCategoryTypeAsync(Guid id, CategoryType request)
        {
            var existingCategoryType = await _context.CategoryTypes.FindAsync(id);
            if (existingCategoryType == null)
            {
                throw new KeyNotFoundException("CategoryType not found.");
            }
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            request.UpdatedBy = _currentUser.UserId;
            request.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingCategoryType).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return existingCategoryType;
        }



        public async Task<Guid> DeleteCategoryTypeAsync(Guid id)
        {
            var company = await _context.CategoryTypes.FindAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("CategoryType not found.");
            }
            _context.CategoryTypes.Remove(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }





        public async Task<List<CategoryTypeResponses>> GetAllCategoryTypeAsync()
        {
            var data = await (
                from ct in _context.CategoryTypes.AsNoTracking()

                join u in _context.Users
                    on ct.CreatedBy equals u.Id

                select new CategoryTypeResponses
                {
                    Id = ct.Id,
                    Name = ct.Name,
                    Description = ct.Description,
                    IsActive = ct.IsActive,
                    CreatedAt = ct.CreatedAt,
                    UpdatedAt = ct.UpdatedAt,
                    CreatedBy = u.FirstName
                }
            ).ToListAsync();

            return data;
        }

        public async Task OpenProductConversionAsync(OpenProductConversionRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1️⃣ Get inventory for FROM product (sack)
                var fromInventory = await _context.Inventories
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == request.FromProductId &&
                        x.BranchId == request.BranchId);

                if (fromInventory == null || fromInventory.Quantity < request.OpenQuantity)
                    throw new Exception("Not enough sack stock to open.");

                // 2️⃣ Get inventory for TO product (loose)
                var toInventory = await _context.Inventories
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == request.ToProductId &&
                        x.BranchId == request.BranchId);

                if (toInventory == null)
                    throw new Exception("Loose product inventory not found.");

                // 3️⃣ Update inventories
                fromInventory.Quantity -= request.OpenQuantity;
                toInventory.Quantity += request.OpenQuantity * request.ConversionValue;

                fromInventory.UpdatedAt = DateTime.UtcNow;
                toInventory.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // 4️⃣ Commit
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }




        public async Task ReceiveStockAsync(ReceiveStockRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1️⃣ Find inventory for product + branch
                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == request.ProductId &&
                        x.BranchId == request.BranchId);

                if (inventory == null)
                    throw new Exception("Inventory not found. Create inventory first.");

                // 2️⃣ Increase stock
                inventory.Quantity += request.Quantity;
                inventory.UpdatedAt = DateTime.UtcNow;
                inventory.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();

                // 3️⃣ Commit
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }






    }
}
