using Application.Common.Request;
using Application.Common.Response;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly ISalesService  _salesService;

        public FinancialReportService(
            ISalesService salesService,
            AppDbContext context,
            ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
            _salesService = salesService;
        }

        // =========================
        // EXPENSE CATEGORY
        // =========================
        public async Task<ExpenseCategory> CreateExpenseCategoryAsync(
            CreateExpenseCategoryRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            var exists = await _context.ExpenseCategories
                .AnyAsync(x => x.Name == request.Name);

            if (exists)
                throw new InvalidOperationException("Expense category already exists");

            var category = new ExpenseCategory
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _currentUser.UserId
            };

            await _context.ExpenseCategories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<ExpenseCategory> EditExpenseCategoryAsync(
            EditExpenseCategoryRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            var category = await _context.ExpenseCategories
                .FirstOrDefaultAsync(x => x.Id == request.Id)
                ?? throw new InvalidOperationException("Expense category not found");

            category.Name = request.Name;
            category.Description = request.Description;
            category.IsActive = request.IsActive;
            category.UpdatedAt = DateTime.UtcNow;
            category.UpdatedBy = _currentUser.UserId;

            await _context.SaveChangesAsync();
            return category;
        }

        // =========================
        // EXPENSE MANAGEMENT
        // =========================
        public async Task CreateExpenseAsync(CreateExpenseRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            var branchId = await _salesService.GetUserBranchIdAsync(_currentUser.UserId);

            var expense = new Expense
            {
                ExpenseCategoryId = request.ExpenseCategoryId,
                BranchId =branchId,
                Amount = request.Amount,
                ExpenseDate = request.ExpenseDate,
                Remark = request.Remark,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _currentUser.UserId
            };

            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExpenseListResponse>> GetExpensesAsync(
       Guid? branchId,
       DateTime? fromDate,
       DateTime? toDate)
        {
            var query =
                from e in _context.Expenses.AsNoTracking()
                join c in _context.ExpenseCategories on e.ExpenseCategoryId equals c.Id
                join b in _context.Branches on e.BranchId equals b.Id
                join u in _context.Users on e.CreatedBy equals u.Id into userJoin
                from u in userJoin.DefaultIfEmpty() // LEFT JOIN
                select new { e, c, b, u };

            // 🔹 Optional Branch filter
            if (branchId.HasValue && branchId.Value != Guid.Empty)
            {
                query = query.Where(x => x.e.BranchId == branchId.Value);
            }

            // 🔹 Optional FromDate filter
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.e.ExpenseDate >= fromDate.Value);
            }

            // 🔹 Optional ToDate filter
            if (toDate.HasValue)
            {
                query = query.Where(x => x.e.ExpenseDate <= toDate.Value);
            }

            return await query
                .OrderByDescending(x => x.e.ExpenseDate)
                .Select(x => new ExpenseListResponse
                {
                    ExpenseId = x.e.Id,
                    CategoryName = x.c.Name,
                    BranchName = x.b.BranchName,
                    Amount = x.e.Amount,
                    ExpenseDate = x.e.CreatedAt,
                    Remark = x.e.Remark,

                    // ✅ CREATED USER (safe)
                    CreateBy = x.u != null
                        ? x.u.FirstName        // or Email / FullName
                        : "System"
                })
                .ToListAsync();
        }



        public async Task<decimal> GetTotalExpensesAsync(
            Guid? branchId,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // 🔹 Normalize dates (UTC, default = current month)
            var utcFromDate = fromDate?.ToUniversalTime()
                ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var utcToDate = toDate?.ToUniversalTime()
                ?? utcFromDate.AddMonths(1).AddTicks(-1);

            var query = _context.Expenses
                .AsNoTracking()
                .Where(x =>
                    x.CreatedAt >= utcFromDate &&
                    x.CreatedAt <= utcToDate);

            // 🔹 Optional branch filter
            if (branchId.HasValue && branchId.Value != Guid.Empty)
            {
                query = query.Where(x => x.BranchId == branchId.Value);
            }

            return await query.SumAsync(x => x.Amount);
        }


        // =========================
        // REVENUE (SALES)
        // =========================
        public async Task<decimal> GetTotalRevenueAsync(
          Guid? branchId,
          DateTime? fromDate,
          DateTime? toDate)
        {
            // 🔹 Normalize dates (UTC, default = current month)
            var utcFromDate = fromDate?.ToUniversalTime()
                ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var utcToDate = toDate?.ToUniversalTime()
                ?? utcFromDate.AddMonths(1).AddTicks(-1);

            var query = _context.Sales
                .AsNoTracking()
                .Where(x =>
                    x.SaleDate >= utcFromDate &&
                    x.SaleDate <= utcToDate &&
                    x.PaymentStatus != "CANCELLED");

            // 🔹 Optional branch filter
            if (branchId.HasValue && branchId.Value != Guid.Empty)
            {
                query = query.Where(x => x.BranchId == branchId.Value);
            }

            return await query.SumAsync(x => x.TotalAmount);
        }


        public async Task<decimal> GetTotalCogsAsync(
            Guid? branchId,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // 🔹 Normalize dates (UTC, default = current month)
            var utcFromDate = fromDate?.ToUniversalTime()
                ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var utcToDate = toDate?.ToUniversalTime()
                ?? utcFromDate.AddMonths(1).AddTicks(-1);

            var query =
                from si in _context.SaleItems.AsNoTracking()
                join p in _context.Products on si.ProductId equals p.Id
                join s in _context.Sales on si.SaleId equals s.Id
                where s.SaleDate >= utcFromDate
                      && s.SaleDate <= utcToDate
                select new { si, p, s };

            // 🔹 Optional branch filter
            if (branchId.HasValue && branchId.Value != Guid.Empty)
            {
                query = query.Where(x => x.s.BranchId == branchId.Value);
            }

            return await query.SumAsync(x => x.si.Quantity * x.p.CostPrice);
        }


        public async Task<IncomeStatementResponse> GetIncomeStatementAsync(
            Guid? branchId,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // 🔹 Normalize dates ONCE (UTC, current month default)
            var utcFromDate = fromDate?.ToUniversalTime()
                ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var utcToDate = toDate?.ToUniversalTime()
                ?? utcFromDate.AddMonths(1).AddTicks(-1);

            var revenue = await GetTotalRevenueAsync(branchId, utcFromDate, utcToDate);
            var cogs = await GetTotalCogsAsync(branchId, utcFromDate, utcToDate);
            var expenses = await GetTotalExpensesAsync(branchId, utcFromDate, utcToDate);

            return new IncomeStatementResponse
            {
                Revenue = revenue,
                CostOfGoodsSold = cogs,
                GrossProfit = revenue - cogs,
                OperatingExpenses = expenses,
                NetProfit = revenue - cogs - expenses
            };
        }


        // =========================
        // EXPENSE BREAKDOWN
        // =========================
        public async Task<List<ExpenseCategorySummaryResponse>> GetExpenseBreakdownAsync(
     Guid? branchId,
     DateTime? fromDate,
     DateTime? toDate)
        {
            // 🔹 Normalize dates (UTC, current month default)
            var utcFromDate = fromDate?.ToUniversalTime()
                ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var utcToDate = toDate?.ToUniversalTime()
                ?? utcFromDate.AddMonths(1).AddTicks(-1);

            var query =
                from e in _context.Expenses.AsNoTracking()
                join c in _context.ExpenseCategories on e.ExpenseCategoryId equals c.Id
                where e.CreatedAt >= utcFromDate
                      && e.CreatedAt <= utcToDate
                select new { e, c };

            // 🔹 Optional branch filter
            if (branchId.HasValue && branchId.Value != Guid.Empty)
            {
                query = query.Where(x => x.e.BranchId == branchId.Value);
            }

            return await query
                .GroupBy(x => x.c.Name)
                .Select(g => new ExpenseCategorySummaryResponse
                {
                    CategoryName = g.Key,
                    TotalAmount = g.Sum(x => x.e.Amount),

                    // ✅ Latest created date in this category
                    LastExpenseAt = g.Max(x => x.e.CreatedAt)
                })
                .ToListAsync();
        }




        public async Task<List<ExpenseTypeResponse>> GetIExpenseTypeAsync()
        {
            var data = await (
                from ec in _context.ExpenseCategories
                join u in _context.Users
                    on ec.CreatedBy equals u.Id
                select new ExpenseTypeResponse
                {
                    Id = ec.Id,
                    IsActive = ec.IsActive,
                    CreatedAt = ec.CreatedAt,
                    CreatedBy = u.FirstName,
                    Name = ec.Name,
                    Description =ec.Description

                }
            ).ToListAsync();

            return data;
        }





        // =========================
        // REVENUE BREAKDOWN
        // =========================
        public async Task<List<RevenueSummaryResponse>> GetRevenueBreakdownAsync(
      Guid? branchId,
      DateTime? fromDate,
      DateTime? toDate)
        {
            // 🔹 Default to current month (UTC)
            var utcFromDate = fromDate?.ToUniversalTime()
                ?? new DateTime(
                    DateTime.UtcNow.Year,
                    DateTime.UtcNow.Month,
                    1, 0, 0, 0,
                    DateTimeKind.Utc);

            var utcToDate = toDate?.ToUniversalTime()
                ?? utcFromDate.AddMonths(1).AddTicks(-1);

            var query = _context.Sales
                .AsNoTracking()
                .Where(x =>
                    x.SaleDate >= utcFromDate &&
                    x.SaleDate <= utcToDate &&
                    x.PaymentStatus != "CANCELLED");

            // 🔹 Optional branch filter
            if (branchId.HasValue && branchId.Value != Guid.Empty)
            {
                query = query.Where(x => x.BranchId == branchId.Value);
            }

            return await query
                .GroupBy(x => x.SaleDate.Date)
                .Select(g => new RevenueSummaryResponse
                {
                    Period = g.Key,
                    TotalRevenue = g.Sum(x => x.TotalAmount),

                    // ✅ Aggregated CreatedAt
                    LastCreatedAt = g.Max(x => x.CreatedAt)
                })
                .OrderBy(x => x.Period)
                .ToListAsync();
        }




        public async Task<IncomeStatementReportResponse> GetIncomeStatementReportAsync(
    Guid? branchId,
    DateTime? fromDate,
    DateTime? toDate)
        {
            // 1️⃣ Normalize dates ONCE (UTC, current month default)
            var utcFrom = fromDate?.ToUniversalTime()
                ?? new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var utcTo = toDate?.ToUniversalTime()
                ?? utcFrom.AddMonths(1).AddTicks(-1);

            // 2️⃣ Get totals (already validated & correct)
            var revenueTotal = await GetTotalRevenueAsync(branchId, utcFrom, utcTo);
            var cogsTotal = await GetTotalCogsAsync(branchId, utcFrom, utcTo);
            var expenseTotal = await GetTotalExpensesAsync(branchId, utcFrom, utcTo);

            // 3️⃣ Get breakdowns
            var expenseBreakdown = await GetExpenseBreakdownAsync(branchId, utcFrom, utcTo);

            var grossProfit = revenueTotal - cogsTotal;
            var netProfit = grossProfit - expenseTotal;

            // 4️⃣ Build PROFESSIONAL REPORT
            return new IncomeStatementReportResponse
            {
                Period = new ReportPeriod
                {
                    From = utcFrom,
                    To = utcTo
                },

                Revenue = new ReportSection
                {
                    Title = "REVENUE",
                    Lines = new List<ReportLine>
            {
                new ReportLine
                {
                    Name = "Sales",
                    Amount = revenueTotal
                }
            },
                    Total = revenueTotal
                },

                CostOfGoodsSold = new ReportSection
                {
                    Title = "COST OF GOODS SOLD",
                    Lines = new List<ReportLine>
            {
                new ReportLine
                {
                    Name = "Cost of Goods Sold",
                    Amount = cogsTotal
                }
            },
                    Total = cogsTotal
                },

                GrossProfit = new ReportSingleLine
                {
                    Title = "GROSS PROFIT",
                    Amount = grossProfit
                },

                OperatingExpenses = new ReportSection
                {
                    Title = "OPERATING EXPENSES",
                    Lines = expenseBreakdown.Select(x => new ReportLine
                    {
                        Name = x.CategoryName,
                        Amount = x.TotalAmount
                    }).ToList(),
                    Total = expenseTotal
                },

                NetProfit = new ReportSingleLine
                {
                    Title = "NET PROFIT",
                    Amount = netProfit
                }
            };
        }


    }
}
