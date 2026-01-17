using Application.Common.Helper;
using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // =========================
        // CREATE PRODUCT + INVENTORY
        // =========================
        public async Task<Product> CreateProductWithInventoryAsync(
          Product product,
          Guid branchId,
          decimal quantity,
          decimal minStockLevel)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1️⃣ Create product
                product.CreatedBy = _currentUser.UserId;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                // 2️⃣ Create inventory
                await _context.Inventories.AddAsync(new Inventory
                {
                    ProductId = product.Id,
                    BranchId = branchId,
                    Quantity = quantity,
                    MinStockLevel = minStockLevel,
                    CreatedBy = _currentUser.UserId,
                    CreatedAt = DateTime.UtcNow
                });

                // 3️⃣ Create initial stock movement (WITH Reference)
                if (quantity > 0)
                {
                    var reference = $"RCV-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..8]}";

                    _context.StockMovements.Add(new StockMovement
                    {
                        ProductId = product.Id,
                        BranchId = branchId,
                        QuantityChange = quantity,
                        MovementType = StockMovementTypes.Receive,
                        Reason = "Initial stock",
                        Reference = reference,               // ✅ REQUIRED
                        CreatedBy = _currentUser.UserId,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
                return product;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }


        // =========================
        // UPDATE PRODUCT + INVENTORY
        // =========================
        public async Task<Product> UpdateProductWithInventoryAsync(
            Guid productId,
            Product request,
            Guid branchId,
            decimal quantity,
            decimal minStockLevel)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                var product = await _context.Products.FindAsync(productId)
                    ?? throw new KeyNotFoundException("Product not found");

                product.Name = request.Name;
                product.CategoryId = request.CategoryId;
                product.CategoryTypeId = request.CategoryTypeId;
                product.Unit = request.Unit;
                product.CostPrice = request.CostPrice;
                product.SellPrice = request.SellPrice;
                product.WholesalePrice = request.WholesalePrice;
                product.UpdatedAt = DateTime.UtcNow;
                product.UpdatedBy = _currentUser.UserId;

                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(x => x.ProductId == productId && x.BranchId == branchId)
                    ?? throw new KeyNotFoundException("Inventory not found");

                inventory.Quantity = quantity;
                inventory.MinStockLevel = minStockLevel;
                inventory.UpdatedAt = DateTime.UtcNow;
                inventory.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
                return product;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        // =========================
        // DELETE / GET PRODUCT
        // =========================
        public async Task<Guid> DeleteProdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id)
                ?? throw new KeyNotFoundException("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<Product?> GetByIdProdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        // =========================
        // PAGED PRODUCTS BY BRANCH
        // =========================
        public async Task<List<ProductResponses>> GetAllProductsAsync()
        {
            return await (
                from p in _context.Products.AsNoTracking()

                join c in _context.Categories
                    on p.CategoryId equals c.Id

                join ct in _context.CategoryTypes
                    on p.CategoryTypeId equals ct.Id

                // LEFT JOIN Inventory
                join i in _context.Inventories
                    on p.Id equals i.ProductId into inv
                from inventory in inv.DefaultIfEmpty()

                    // LEFT JOIN Users (CreatedBy)
                join u in _context.Users
                    on p.CreatedBy equals u.Id into users
                from user in users.DefaultIfEmpty()

                select new ProductResponses
                {
                    Id = p.Id,
                    Name = p.Name,
                    Unit = p.Unit,
                    CostPrice = p.CostPrice,
                    SellPrice = p.SellPrice,
                    WholesalePrice = p.WholesalePrice,

                    CategoryName = c.Name,
                    CategoryTypeName = ct.Name,

                    Quantity = inventory != null ? inventory.Quantity : 0,

                    CreatedAt = p.CreatedAt,

                    // ✅ FIXED: creator username (null-safe)
                    CreatedBy = user != null ? user.UserName : "System",

                    Description = p.Description
                }
            ).ToListAsync();
        }



        public async Task<List<ProductQntyResponses>> GetAllProductsQntyAsync()
        {
            return await (
                from p in _context.Products.AsNoTracking()
                join i in _context.Inventories
                    on p.Id equals i.ProductId into inv
                from inventory in inv.DefaultIfEmpty()

                select new ProductQntyResponses
                {
                    Id = p.Id,
                    Name = p.Name,
                    Unit = p.Unit,
                    SellPrice = p.SellPrice,
                    WholesalePrice = p.WholesalePrice,
                    Quantity = inventory != null ? inventory.Quantity : 0,

                }
            ).ToListAsync();
        }





        public async Task<CategoryType> CreateCategoryTypeAsync(CategoryType request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();


            request.CreatedBy = _currentUser.UserId;
            await _context.CategoryTypes.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<CategoryType> UpdateCategoryTypeAsync(Guid id, CategoryType request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            var entity = await _context.CategoryTypes.FindAsync(id)
                ?? throw new KeyNotFoundException("CategoryType not found.");

            // ✅ VALIDATE FOREIGN KEY
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == request.CategoryId);

            if (!categoryExists)
                throw new InvalidOperationException("Invalid CategoryId.");

            // ✅ Safe updates
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.IsActive = request.IsActive;
            entity.CategoryId = request.CategoryId;

            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedBy = _currentUser.UserId;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Guid> DeleteCategoryTypeAsync(Guid id)
        {
            var entity = await _context.CategoryTypes.FindAsync(id)
                ?? throw new KeyNotFoundException();

            _context.CategoryTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<CategoryTypeResponses>> GetAllCategoryTypeAsync()
        {
            return await (
                from ct in _context.CategoryTypes.AsNoTracking()

                join c in _context.Categories
                    on ct.CategoryId equals c.Id

                join u in _context.Users
                    on ct.CreatedBy equals u.Id

                select new CategoryTypeResponses
                {
                    Id = ct.Id,
                    Name = ct.Name,
                    Description = ct.Description,
                    CategoryName = c.Name,        // ✅ from Category table
                    CreatedBy = u.FirstName,      // ✅ from User table

                    CreatedAt = ct.CreatedAt,
                    UpdatedAt = ct.UpdatedAt
                }
            ).ToListAsync();
        }

        // =========================
        // STOCK OPERATIONS
        // =========================
        public async Task ReceiveStockAsync(ReceiveStockRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            if (request.Quantity <= 0)
                throw new InvalidOperationException("Quantity must be greater than zero");

            // ✅ Unique reference for traceability
            var reference = $"RCV-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid():N}".Substring(0, 22);

            using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                // =========================
                // 1️⃣ GET OR CREATE INVENTORY
                // =========================
                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == request.ProductId &&
                        x.BranchId == request.BranchId);

                if (inventory == null)
                {
                    inventory = new Inventory
                    {
                        ProductId = request.ProductId,
                        BranchId = request.BranchId,
                        Quantity = request.Quantity,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = _currentUser.UserId
                    };

                    await _context.Inventories.AddAsync(inventory);
                }
                else
                {
                    // ✅ Increase existing stock
                    inventory.Quantity += request.Quantity;
                }

                // =========================
                // 2️⃣ STOCK MOVEMENT (AUDIT)
                // =========================
                _context.StockMovements.Add(new StockMovement
                {
                    ProductId = request.ProductId,
                    BranchId = request.BranchId,
                    QuantityChange = request.Quantity,
                    MovementType = StockMovementTypes.Receive,
                    Reason = "Stock received",
                    Reference = reference,
                    CreatedBy = _currentUser.UserId,
                    CreatedAt = DateTime.UtcNow
                });

                // =========================
                // 3️⃣ SAVE + COMMIT
                // =========================
                await _context.SaveChangesAsync();
                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }


        public async Task TransferStockAsync(StockTransferRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            using var tx = await _context.Database.BeginTransactionAsync();

            // ✅ 1. Generate transfer reference (VERY IMPORTANT)
            var reference = $"TRF-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..8]}";

            // FROM inventory
            var from = await _context.Inventories.FirstAsync(x =>
                x.ProductId == request.ProductId &&
                x.BranchId == request.FromBranchId);

            if (from.Quantity < request.Quantity)
                throw new Exception("Insufficient stock in source branch.");

            // TO inventory
            var to = await _context.Inventories.FirstOrDefaultAsync(x =>
                x.ProductId == request.ProductId &&
                x.BranchId == request.ToBranchId);

            if (to == null)
            {
                to = new Inventory
                {
                    ProductId = request.ProductId,
                    BranchId = request.ToBranchId,
                    Quantity = 0,
                    MinStockLevel = 0,
                    CreatedBy = _currentUser.UserId,
                    CreatedAt = DateTime.UtcNow
                };

                await _context.Inventories.AddAsync(to);
            }

            // Transfer quantities
            from.Quantity -= request.Quantity;
            to.Quantity += request.Quantity;

            from.UpdatedAt = DateTime.UtcNow;
            to.UpdatedAt = DateTime.UtcNow;
            from.UpdatedBy = _currentUser.UserId;
            to.UpdatedBy = _currentUser.UserId;

            // ✅ 2. Stock movements with SAME reference
            _context.StockMovements.AddRange(
                new StockMovement
                {
                    ProductId = request.ProductId,
                    BranchId = request.FromBranchId,
                    QuantityChange = -request.Quantity,
                    MovementType = StockMovementTypes.TransferOut,
                    Reference = reference,                // ✅ HERE
                    CreatedBy = _currentUser.UserId,
                    CreatedAt = DateTime.UtcNow
                },
                new StockMovement
                {
                    ProductId = request.ProductId,
                    BranchId = request.ToBranchId,
                    QuantityChange = request.Quantity,
                    MovementType = StockMovementTypes.TransferIn,
                    Reference = reference,                // ✅ SAME REFERENCE
                    CreatedBy = _currentUser.UserId,
                    CreatedAt = DateTime.UtcNow
                });

            await _context.SaveChangesAsync();
            await tx.CommitAsync();
        }






        public async Task<List<StockTransferResponse>> GetAllStockTransfersAsync()
        {
            var query =
                from outMove in _context.StockMovements.AsNoTracking()
                where outMove.MovementType == StockMovementTypes.TransferOut

                join inMove in _context.StockMovements.AsNoTracking()
                    on outMove.Reference equals inMove.Reference
                where inMove.MovementType == StockMovementTypes.TransferIn

                join p in _context.Products on outMove.ProductId equals p.Id
                join fb in _context.Branches on outMove.BranchId equals fb.Id
                join tb in _context.Branches on inMove.BranchId equals tb.Id
                join u in _context.Users on outMove.CreatedBy equals u.Id

                orderby outMove.CreatedAt descending

                select new StockTransferResponse
                {
                    ProductId = p.Id,
                    ProductName = p.Name,

                    FromBranchId = fb.Id,
                    FromBranchName = fb.BranchName,

                    ToBranchId = tb.Id,
                    ToBranchName = tb.BranchName,

                    // ✅ EF-safe + nullable-safe
                    Quantity =
                        (outMove.QuantityChange ?? 0) < 0
                            ? -(outMove.QuantityChange ?? 0)
                            : (outMove.QuantityChange ?? 0),

                    TransferDate = outMove.CreatedAt,
                    TransferredBy = u.UserName ?? string.Empty
                };

            return await query.ToListAsync();
        }



        public async Task<List<ProductWithCategoryAndWithCategoryTypeAndBranchResponses>>
            ProductWithCategoryAndWithCategoryTypeAsync()
        {
            var data = await (
                from p in _context.Products.AsNoTracking()

                join cat in _context.Categories
                    on p.CategoryId equals cat.Id

                join cty in _context.CategoryTypes
                    on p.CategoryTypeId equals cty.Id

                join i in _context.Inventories
                    on p.Id equals i.ProductId

                join b in _context.Branches
                    on i.BranchId equals b.Id

                select new ProductWithCategoryAndWithCategoryTypeAndBranchResponses
                {
                    // PRODUCT
                    ProductId = p.Id,
                    Name = p.Name,
                    CategoryName = cat.Name,
                    CategoryTypeName = cty.Name,
                    BranchId = b.Id,
                    BranchName = b.BranchName,

                    // PRODUCT DETAILS
                    Price = p.SellPrice,
                    WholePrice = p.WholesalePrice,
                    Quantity = i.Quantity,
                }
            ).ToListAsync();

            return data;
        }












        public async Task AdjustStockAsync(StockAdjustmentRequest request)
        {

            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();



            var inventory = await _context.Inventories.FirstAsync(x =>
                x.ProductId == request.ProductId && x.BranchId == request.BranchId);

            var diff = request.NewQuantity - inventory.Quantity;
            inventory.Quantity = request.NewQuantity;

            _context.StockMovements.Add(new StockMovement
            {
                ProductId = request.ProductId,
                BranchId = request.BranchId,
                QuantityChange = diff,
                MovementType = StockMovementTypes.Adjustment,
                Reason = request.Reason,
                CreatedBy = _currentUser.UserId,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        // =========================
        // STOCK QUERIES
        // =========================
        public async Task<List<StockListResponse>> GetStockListAsync(Guid? branchId = null)
        {
            return await (
                from i in _context.Inventories.AsNoTracking()
                join p in _context.Products on i.ProductId equals p.Id
                join b in _context.Branches on i.BranchId equals b.Id
                where !branchId.HasValue || i.BranchId == branchId
                select new StockListResponse
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Unit = p.Unit,
                    BranchId = b.Id,
                    BranchName = b.BranchName,
                    Quantity = i.Quantity,
                    MinStockLevel = i.MinStockLevel
                }).ToListAsync();
        }

        public async Task<List<StockMovementResponse>> GetAllStockMovementsAsync()
        {
            return await (
                from sm in _context.StockMovements.AsNoTracking()
                join p in _context.Products on sm.ProductId equals p.Id
                join b in _context.Branches on sm.BranchId equals b.Id
                join u in _context.Users on sm.CreatedBy equals u.Id
                select new StockMovementResponse
                {
                    StockMovementId = sm.Id,
                    ProductName = p.Name,
                    BranchName = b.BranchName,
                    QuantityChange = sm.QuantityChange,
                    MovementType = sm.MovementType,
                    Reason = sm.Reason,
                    CreatedBy = u.UserName,
                    CreatedAt = sm.CreatedAt
                }).ToListAsync();
        }

        public async Task OpenProductConversionAsync(OpenProductConversionRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            // ✅ Generate conversion reference
            var reference = $"CNV-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..8]}";

            var from = await _context.Inventories.FirstAsync(x =>
                x.ProductId == request.FromProductId &&
                x.BranchId == request.BranchId);

            var to = await _context.Inventories.FirstAsync(x =>
                x.ProductId == request.ToProductId &&
                x.BranchId == request.BranchId);

            if (from.Quantity < request.OpenQuantity)
                throw new Exception("Insufficient stock to convert.");

            // Apply conversion
            from.Quantity -= request.OpenQuantity;
            to.Quantity += request.OpenQuantity * request.ConversionValue;

            from.UpdatedAt = DateTime.UtcNow;
            to.UpdatedAt = DateTime.UtcNow;
            from.UpdatedBy = _currentUser.UserId;
            to.UpdatedBy = _currentUser.UserId;

            // ✅ Save conversion audit with reference
            _context.StockMovements.Add(new StockMovement
            {
                ProductId = request.FromProductId,
                BranchId = request.BranchId,
                QuantityChange = -request.OpenQuantity,
                MovementType = StockMovementTypes.Conversion,
                Reason = $"Converted to product {request.ToProductId}",
                Reference = reference,                // ✅ REQUIRED
                CreatedBy = _currentUser.UserId,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }



        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }







    }
}
