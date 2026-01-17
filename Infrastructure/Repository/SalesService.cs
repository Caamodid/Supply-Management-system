using Application.Common.Helper;
using Application.Common.Request;
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

namespace Infrastructure.Repository
{
    public class SalesService : ISalesService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public SalesService(AppDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }




        public async Task<Guid> GetUserBranchIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new UnauthorizedAccessException("Invalid user");

            Guid? branchId = await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => u.BranchId)
                .FirstOrDefaultAsync();

            if (!branchId.HasValue)
                throw new InvalidOperationException("Branch not found for user");

            return branchId.Value; // ✅ FIX
        }








        public async Task<Sale> CreateSaleWithItemsAsync(CreateSalesAndSaleItemRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            // ✅ ALWAYS get branch from logged-in user
            var branchId = await GetUserBranchIdAsync(_currentUser.UserId);
            


            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // =========================
                // 1️⃣ CREATE SALE (HEADER)
                // =========================
                var sale = new Sale
                {
                    InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..4].ToUpper()}",
                    CustomerId = request.Sale.CustomerId,
                    BranchId = branchId,
                    IsWalkIn =request.Sale.IsWalkIn,

                    SubTotal = 0,
                    Discount = request.Sale.Discount,
                    TotalAmount = 0,
                    PaidAmount = request.Sale.PaidAmount,
                    Balance = 0,

                    PaymentStatus = "PENDING",
                    SaleDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _currentUser.UserId
                };

                await _context.Sales.AddAsync(sale);
                await _context.SaveChangesAsync(); // 🔑 Get SaleId

                decimal subTotal = 0;

                // =========================
                // 2️⃣ LOOP SALE ITEMS
                // =========================
                foreach (var item in request.Items)
                {
                    var inventory = await _context.Inventories.FirstOrDefaultAsync(x =>
                        x.ProductId == item.ProductId &&
                        x.BranchId == sale.BranchId)
                        ?? throw new InvalidOperationException("Inventory not found");

                    if (inventory.Quantity < item.Quantity)
                        throw new InvalidOperationException("Insufficient stock");

                    var lineTotal = item.Quantity * item.UnitPrice;

                    var saleItem = new SaleItem
                    {
                        SaleId = sale.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        LineTotal = lineTotal,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = _currentUser.UserId
                    };

                    await _context.SaleItems.AddAsync(saleItem);

                    // ✅ Reduce stock (tracked by EF)
                    inventory.Quantity -= item.Quantity;

                    // ✅ Stock movement audit
                    _context.StockMovements.Add(new StockMovement
                    {
                        ProductId = item.ProductId,
                        BranchId = sale.BranchId,
                        QuantityChange = -item.Quantity,
                        MovementType = StockMovementTypes.Sale,
                        Reference = $"SAL-{sale.InvoiceNumber}",
                        CreatedBy = _currentUser.UserId,
                        CreatedAt = DateTime.UtcNow
                    });

                    subTotal += lineTotal;
                }

                // =========================
                // 3️⃣ UPDATE TOTALS + STATUS
                // =========================
                sale.SubTotal = subTotal;
                sale.TotalAmount = subTotal - sale.Discount;
                sale.Balance = sale.TotalAmount - sale.PaidAmount;

                if (sale.Balance <= 0)
                {
                    sale.PaymentStatus = "CLOSED";
                    sale.Remark = "Completed";
                }
                else if (sale.PaidAmount > 0)
                {
                    sale.PaymentStatus = "PARTIAL";

                    if (string.IsNullOrWhiteSpace(request.Sale.Remark))
                        throw new InvalidOperationException("Remark is required for partial payment");

                    sale.Remark = request.Sale.Remark;
                }
                else
                {
                    sale.PaymentStatus = "OPEN";

                    if (string.IsNullOrWhiteSpace(request.Sale.Remark))
                        throw new InvalidOperationException("Remark is required for unpaid sale");

                    sale.Remark = request.Sale.Remark;
                }

                await _context.SaveChangesAsync();
                await tx.CommitAsync();

                return sale;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task CancelSaleAsync(CancelSaleRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            if (string.IsNullOrWhiteSpace(request.Remark))
                throw new InvalidOperationException("Cancellation remark is required");

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                var sale = await _context.Sales
                    .FirstOrDefaultAsync(x => x.Id == request.SaleId)
                    ?? throw new InvalidOperationException("Sale not found");

                // ❌ Do not allow cancel after closed
                if (sale.PaymentStatus == "CLOSED")
                    throw new InvalidOperationException("Closed sale cannot be cancelled");


                if (sale.PaymentStatus == "PARTIAL")
                    throw new InvalidOperationException("PARTIAL sale cannot be cancelled");

                // ❌ Do not allow double cancel
                if (sale.PaymentStatus == "CANCELLED")
                    throw new InvalidOperationException("Sale is already cancelled");

                var saleItems = await _context.SaleItems
                    .Where(x => x.SaleId == sale.Id)
                    .ToListAsync();

                foreach (var item in saleItems)
                {
                    var inventory = await _context.Inventories.FirstAsync(x =>
                        x.ProductId == item.ProductId &&
                        x.BranchId == sale.BranchId);

                    // ✅ Restore stock ONCE
                    inventory.Quantity += item.Quantity;

                    // Stock movement (audit)
                    _context.StockMovements.Add(new StockMovement
                    {
                        ProductId = item.ProductId,
                        BranchId = sale.BranchId,
                        QuantityChange = item.Quantity,
                        MovementType = StockMovementTypes.CancelSale,
                        Reference = $"CNL-{sale.InvoiceNumber}",
                        Reason = request.Remark,
                        CreatedBy = _currentUser.UserId,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                // Mark sale cancelled
                sale.PaymentStatus = "CANCELLED";
                sale.Remark = request.Remark;
                sale.UpdatedAt = DateTime.UtcNow;
                sale.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task PayRemainingAsync(PayRemainingRequest request)
        {


            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            if (request.Amount <= 0)
                throw new InvalidOperationException("Invalid payment amount");

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                var sale = await _context.Sales
                    .FirstOrDefaultAsync(x => x.Id == request.SaleId)
                    ?? throw new InvalidOperationException("Sale not found");

                if (sale.PaymentStatus == "CLOSED")
                    throw new InvalidOperationException("Sale already closed");

                if (request.Amount > sale.Balance)
                    throw new InvalidOperationException("Payment exceeds balance");

                if (sale.PaymentStatus == "CANCELLED")
                    throw new InvalidOperationException("Cancelled sale cannot receive payment");


                // =========================
                // UPDATE PAYMENT
                // =========================
                sale.PaidAmount += request.Amount;
                sale.Balance -= request.Amount;

                // =========================
                // UPDATE STATUS + REMARK
                // =========================
                if (sale.Balance <= 0)
                {
                    sale.PaymentStatus = "CLOSED";
                    sale.Remark = null; // ✅ no remark needed anymore
                }
                else
                {
                    sale.PaymentStatus = "PARTIAL";

                    // ✅ Save reason why payment is still partial
                    if (string.IsNullOrWhiteSpace(request.Remark))
                        throw new InvalidOperationException("Remark is required for partial payment");

                    sale.Remark = request.Remark;
                }

                sale.UpdatedAt = DateTime.UtcNow;
                sale.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task<SaleDetailResponse> GetSaleDetailAsync(Guid saleId)
        {
            var sale = await (
                from s in _context.Sales.AsNoTracking()
                join c in _context.Customers on s.CustomerId equals c.Id
                join b in _context.Branches on s.BranchId equals b.Id
                join u in _context.Users on s.CreatedBy equals u.Id
                where s.Id == saleId
                select new SaleDetailResponse
                {
                    SaleId = s.Id,
                    InvoiceNumber = s.InvoiceNumber,

                    CustomerName = c.Name,
                    BranchName = b.BranchName,

                    SubTotal = s.SubTotal,
                    Discount = s.Discount,
                    TotalAmount = s.TotalAmount,
                    PaidAmount = s.PaidAmount,
                    Balance = s.Balance,
                    Remark = s.Remark,
                    PaymentStatus = s.PaymentStatus,
                    SaleDate = s.SaleDate,

                    // ✅ CREATED BY
                    CreatedBy = u.FirstName
                }
            ).FirstOrDefaultAsync()
            ?? throw new InvalidOperationException("Sale not found");

            sale.Items = await (
                from i in _context.SaleItems.AsNoTracking()
                join p in _context.Products on i.ProductId equals p.Id
                where i.SaleId == saleId
                select new SaleItemDetailResponse
                {
                    ProductName = p.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    LineTotal = i.LineTotal
                }
            ).ToListAsync();

            return sale;
        }


        public async Task<List<SalesListResponse>> GetAllSalesAsync()
        {
            return await (
                from s in _context.Sales.AsNoTracking()
                join c in _context.Customers on s.CustomerId equals c.Id
                join b in _context.Branches on s.BranchId equals b.Id
                orderby s.SaleDate descending
                select new SalesListResponse
                {
                    SaleId = s.Id,
                    InvoiceNumber = s.InvoiceNumber,

                    CustomerName = c.Name,
                    BranchName = b.BranchName,

                    SubTotal = s.SubTotal,
                    Discount = s.Discount,
                    TotalAmount = s.TotalAmount,
                    PaidAmount = s.PaidAmount,
                    Balance = s.Balance,

                    PaymentStatus = s.PaymentStatus,
                    SaleDate = s.SaleDate
                }
            ).ToListAsync();
        }

        public async Task<List<CustomerCreditResponse>> GetCustomerCreditsAsync(string InvoiceNo, DateTime FromDate, DateTime ToDate)
        {
            // Default the FromDate and ToDate if they are not provided
            if (FromDate == default)
            {
                // Set FromDate to the first day of this month
                FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            if (ToDate == default)
            {
                // Set ToDate to the last day of this month
                ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }

            var data = await (
                from s in _context.Sales.AsNoTracking()
                join c in _context.Customers on s.CustomerId equals c.Id
                where s.Balance > 0
                      && s.PaymentStatus != "CLOSED"
                      && s.PaymentStatus != "CANCELLED"
                      // Apply filters based on parameters
                      && (string.IsNullOrEmpty(InvoiceNo) || s.InvoiceNumber == InvoiceNo)
                      && s.SaleDate >= FromDate
                      && s.SaleDate <= ToDate
                group s by new { c.Id, c.Name, c.Phone } into g
                select new
                {
                    CustomerId = g.Key.Id,
                    CustomerName = g.Key.Name,
                    CustomerPhone = g.Key.Phone,
                    InvoiceNumber = g.Select(x => x.InvoiceNumber).FirstOrDefault(),
                    TotalCredit = g.Sum(x => x.Balance),
                    UnpaidSalesCount = g.Count(),
                    LastSaleDate = g.Max(x => x.SaleDate),
                    OldestUnpaidDate = g.Min(x => x.SaleDate)
                }
            ).ToListAsync();

            // Map to response + calculate CreditStatus
            return data.Select(x => new CustomerCreditResponse
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                Phone = x.CustomerPhone,
                InvoiceNo = x.InvoiceNumber,
                TotalCredit = x.TotalCredit,
                UnpaidSalesCount = x.UnpaidSalesCount,
                LastSaleDate = x.LastSaleDate,
                OldestUnpaidDate = x.OldestUnpaidDate,
                CreditStatus =
                    x.TotalCredit >= 1000 ? "HIGH" :
                    x.TotalCredit >= 300 ? "MEDIUM" :
                    "LOW"
            }).ToList();
        }



        public async Task<CustomerCreditDetailResponse> GetCustomerCreditDetailAsync(Guid customerId)
        {
            var data = await (
                from c in _context.Customers.AsNoTracking()
                join u in _context.Users.AsNoTracking()
                    on c.CreatedBy equals u.Id
                where c.Id == customerId
                select new
                {
                    Customer = c,
                    CreatedByUserName = u.FirstName
                }
            ).FirstOrDefaultAsync()
            ?? throw new InvalidOperationException("Customer not found");

            var sales = await _context.Sales
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId &&
                    x.Balance > 0 &&
                    x.PaymentStatus != "CLOSED" &&
                    x.PaymentStatus != "CANCELLED")
                .OrderBy(x => x.SaleDate)
                .Select(x => new CustomerCreditSaleDetail
                {
                    SaleId = x.Id,
                    InvoiceNumber = x.InvoiceNumber,
                    SaleDate = x.SaleDate,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount,
                    Balance = x.Balance,
                    PaymentStatus = x.PaymentStatus
                })
                .ToListAsync();

            return new CustomerCreditDetailResponse
            {
                CustomerId = data.Customer.Id,
                CustomerName = data.Customer.Name,
                CustomerPhone = data.Customer.Phone,
                CreateBy = data.CreatedByUserName, // ✅ username
                TotalCredit = sales.Sum(x => x.Balance),
                Sales = sales
            };
        }



        public async Task EditSaleAsync(EditSaleRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                var sale = await _context.Sales
                    .FirstOrDefaultAsync(x => x.Id == request.SaleId)
                    ?? throw new InvalidOperationException("Sale not found");

                // ❌ Only OPEN sales can be edited
                if (sale.PaymentStatus != "OPEN")
                    throw new InvalidOperationException("Only OPEN sales can be edited");

                // =========================
                // 1️⃣ RESTORE OLD STOCK
                // =========================
                var oldItems = await _context.SaleItems
                    .Where(x => x.SaleId == sale.Id)
                    .ToListAsync();

                foreach (var item in oldItems)
                {
                    var inventory = await _context.Inventories.FirstAsync(x =>
                        x.ProductId == item.ProductId &&
                        x.BranchId == sale.BranchId);

                    inventory.Quantity += item.Quantity;
                }

                // Remove old items
                _context.SaleItems.RemoveRange(oldItems);

                // =========================
                // 2️⃣ ADD NEW ITEMS
                // =========================
                decimal subTotal = 0;

                foreach (var item in request.Items)
                {
                    var inventory = await _context.Inventories.FirstAsync(x =>
                        x.ProductId == item.ProductId &&
                        x.BranchId == sale.BranchId);

                    if (inventory.Quantity < item.Quantity)
                        throw new InvalidOperationException("Insufficient stock");

                    var lineTotal = item.Quantity * item.UnitPrice;

                    _context.SaleItems.Add(new SaleItem
                    {
                        SaleId = sale.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        LineTotal = lineTotal,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = _currentUser.UserId
                    });

                    inventory.Quantity -= item.Quantity;
                    subTotal += lineTotal;
                }

                // =========================
                // 3️⃣ UPDATE SALE TOTALS
                // =========================
                sale.SubTotal = subTotal;
                sale.Discount = request.Discount;
                sale.TotalAmount = subTotal - request.Discount;
                sale.Balance = sale.TotalAmount; // still unpaid
                sale.Remark = request.Remark;

                sale.UpdatedAt = DateTime.UtcNow;
                sale.UpdatedBy = _currentUser.UserId;

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }




    }
}