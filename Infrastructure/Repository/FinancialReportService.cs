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



        public async Task DepositAsync(Guid customerId, decimal amount, string remark)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            // start database transaction (VERY important for money)
            using var dbTransaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Get or create wallet
                var wallet = await _context.CustomerWallets
                    .FirstOrDefaultAsync(w => w.CustomerId == customerId);

                if (wallet == null)
                {
                    wallet = new CustomerWallet
                    {
                        CustomerId = customerId,
                        Balance = 0,
                        CreatedBy = _currentUser.UserId,
                    };

                    await _context.CustomerWallets.AddAsync(wallet);
                }

                // 2. Create deposit transaction (ledger record)
                var transaction = new DepositTransaction
                {
                    CustomerId = customerId,
                    Amount = amount, // positive = deposit
                    TransactionType = "Deposit",
                    Remark = remark,
                    CreatedBy = _currentUser.UserId,
                };

                await _context.DepositTransactions.AddAsync(transaction);

                // 3. Update wallet balance
                wallet.Balance += amount;

                // 4. Save changes
                await _context.SaveChangesAsync();

                // 5. Commit DB transaction
                await dbTransaction.CommitAsync();
            }
            catch
            {
                // rollback on any error
                await dbTransaction.RollbackAsync();
                throw;
            }
        }




        public async Task WalletTransactionAsync(
                     Guid customerId,
    decimal amount,
    string transactionType,
    string remark)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (string.IsNullOrWhiteSpace(transactionType))
                throw new ArgumentException("Transaction type is required.");

            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            // Normalize transaction type (safety)
            transactionType = transactionType.Trim();

            // Start DB transaction (VERY IMPORTANT)
            using var dbTransaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Get existing wallet (DO NOT CREATE)
                var wallet = await _context.CustomerWallets
                    .FirstOrDefaultAsync(w => w.CustomerId == customerId);

                if (wallet == null)
                    throw new InvalidOperationException("Customer wallet not found.");

                // 2. Decide balance effect
                decimal signedAmount;

                switch (transactionType)
                {
                    // REDUCE wallet
                    case "Purchase":
                    case "OwnerUse":
                        if (wallet.Balance < amount)
                            throw new InvalidOperationException("Insufficient wallet balance.");

                        signedAmount = -amount;
                        break;

                    // INCREASE wallet
                    case "Refund":
                    case "OwnerReturn":
                        signedAmount = amount;
                        break;

                    default:
                        throw new InvalidOperationException("Invalid transaction type.");
                }

                // 3. Create transaction record (ledger)
                var transaction = new DepositTransaction
                {
                    CustomerId = customerId,
                    Amount = signedAmount,
                    TransactionType = transactionType,
                    Remark = remark,
                   CreatedBy = _currentUser.UserId,
                };

                await _context.DepositTransactions.AddAsync(transaction);

                // 4. Update wallet balance
                wallet.Balance += signedAmount;

                // 5. Save changes
                await _context.SaveChangesAsync();

                // 6. Commit DB transaction
                await dbTransaction.CommitAsync();
            }
            catch
            {
                // Rollback on any failure
                await dbTransaction.RollbackAsync();
                throw;
            }
        }





        public async Task<List<CustomerWalletSimpleResponse>> GetAllWalletCustomersAsync(
      string? phone,
      DateTime? fromDate,
      DateTime? toDate)
        {
            // 🔹 Normalize incoming dates to UTC
            if (fromDate.HasValue && fromDate.Value.Kind == DateTimeKind.Unspecified)
                fromDate = DateTime.SpecifyKind(fromDate.Value, DateTimeKind.Utc);

            if (toDate.HasValue && toDate.Value.Kind == DateTimeKind.Unspecified)
                toDate = DateTime.SpecifyKind(toDate.Value, DateTimeKind.Utc);

            // 🔹 Default date range = current month (UTC)
            if (!fromDate.HasValue && !toDate.HasValue)
            {
                var now = DateTime.UtcNow;

                fromDate = DateTime.SpecifyKind(
                    new DateTime(now.Year, now.Month, 1),
                    DateTimeKind.Utc);

                toDate = DateTime.SpecifyKind(
                    fromDate.Value.AddMonths(1).AddDays(-1),
                    DateTimeKind.Utc);
            }

            var query =
                from w in _context.CustomerWallets
                join c in _context.Customers
                    on w.CustomerId equals c.Id
                join u in _context.Users
                    on w.CreatedBy equals u.Id into userJoin
                from user in userJoin.DefaultIfEmpty()
                select new
                {
                    Wallet = w,
                    Customer = c,
                    UserName = user != null ? user.UserName : null
                };

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query = query.Where(x =>
                    x.Customer.Phone.Contains(phone));
            }

            if (fromDate.HasValue)
            {
                query = query.Where(x =>
                    x.Wallet.CreatedAt >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(x =>
                    x.Wallet.CreatedAt <= toDate.Value);
            }

            var result = await query
                .OrderByDescending(x => x.Wallet.CreatedAt)
                .Select(x => new CustomerWalletSimpleResponse
                {
                    CustomerId = x.Customer.Id,
                    CustomerName = x.Customer.Name,
                    CustomerPhone = x.Customer.Phone,
                    Balance = x.Wallet.Balance,
                    CreatedAt = x.Wallet.CreatedAt,
                    CreatedBy = x.UserName
                })
                .ToListAsync();

            return result;
        }



        public async Task<CustomerTransactionPaperResponse>
        GetCustomerTransactionPaperAsync(
            Guid customerId,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // =========================
            // 0️⃣ Normalize incoming dates to UTC
            // =========================
            if (fromDate.HasValue && fromDate.Value.Kind == DateTimeKind.Unspecified)
                fromDate = DateTime.SpecifyKind(fromDate.Value, DateTimeKind.Utc);

            if (toDate.HasValue && toDate.Value.Kind == DateTimeKind.Unspecified)
                toDate = DateTime.SpecifyKind(toDate.Value, DateTimeKind.Utc);

            // =========================
            // 1️⃣ Default date = current month (UTC)
            // =========================
            if (!fromDate.HasValue && !toDate.HasValue)
            {
                var now = DateTime.UtcNow;

                fromDate = DateTime.SpecifyKind(
                    new DateTime(now.Year, now.Month, 1),
                    DateTimeKind.Utc);

                toDate = DateTime.SpecifyKind(
                    fromDate.Value.AddMonths(1).AddDays(-1),
                    DateTimeKind.Utc);
            }

            // =========================
            // 2️⃣ HEADER: Customer + Wallet
            // =========================
            var header = await (
                from w in _context.CustomerWallets
                join c in _context.Customers
                    on w.CustomerId equals c.Id
                where c.Id == customerId
                select new
                {
                    c.Id,
                    c.Name,
                    c.Phone,
                    w.Balance
                }
            ).FirstOrDefaultAsync();

            if (header == null)
                throw new InvalidOperationException("Customer wallet not found.");

            // =========================
            // 3️⃣ DETAILS: Transactions
            // =========================
            var transactionsQuery =
                from t in _context.DepositTransactions
                join u in _context.Users
                    on t.CreatedBy equals u.Id into userJoin
                from user in userJoin.DefaultIfEmpty()
                where t.CustomerId == customerId
                select new
                {
                    Transaction = t,
                    UserName = user != null ? user.UserName : null
                };

            if (fromDate.HasValue)
            {
                transactionsQuery =
                    transactionsQuery.Where(x =>
                        x.Transaction.CreatedAt >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                transactionsQuery =
                    transactionsQuery.Where(x =>
                        x.Transaction.CreatedAt <= toDate.Value);
            }

            var transactions = await transactionsQuery
                .OrderByDescending(x => x.Transaction.CreatedAt)
                .Select(x => new CustomerTransactionDetailItem
                {
                    TransactionId = x.Transaction.Id,
                    TransactionDate = x.Transaction.CreatedAt,
                    TransactionType = x.Transaction.TransactionType,
                    Amount = x.Transaction.Amount,
                    CreatedBy = x.UserName,
                    Remark = x.Transaction.Remark
                })
                .ToListAsync();

            // =========================
            // 4️⃣ COMBINE (Paper Style)
            // =========================
            return new CustomerTransactionPaperResponse
            {
                CustomerId = header.Id,
                CustomerName = header.Name,
                CustomerPhone = header.Phone,
                Balance = header.Balance,
                Transactions = transactions
            };
        }




    }
}
