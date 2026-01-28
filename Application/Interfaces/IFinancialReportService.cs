using Application.Common.Request;
using Application.Common.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFinancialReportService
    {
        // =========================
        // EXPENSE MANAGEMENT
        // =========================
        Task CreateExpenseAsync(CreateExpenseRequest request);

        Task<List<ExpenseListResponse>> GetExpensesAsync(
            Guid? branchId,
            DateTime? fromDate,
            DateTime ?toDate);

        Task<decimal> GetTotalExpensesAsync(
            Guid ? branchId,
            DateTime? fromDate,
            DateTime? toDate);

        Task<List<ExpenseTypeResponse>> GetIExpenseTypeAsync();

        Task<IncomeStatementReportResponse> GetIncomeStatementReportAsync(
    Guid? branchId,
    DateTime? fromDate,
    DateTime? toDate);

        // =========================
        // REVENUE (SALES)
        // =========================
        Task<decimal> GetTotalRevenueAsync(
            Guid ? branchId,
            DateTime? fromDate,
            DateTime? toDate);

        // =========================
        // COST OF GOODS SOLD (COGS)
        // =========================
        Task<decimal> GetTotalCogsAsync(
            Guid? branchId,
            DateTime? fromDate,
            DateTime? toDate);


        // ===== EXPENSE CATEGORY =====
        Task<ExpenseCategory> CreateExpenseCategoryAsync(CreateExpenseCategoryRequest request);
        Task<ExpenseCategory> EditExpenseCategoryAsync(EditExpenseCategoryRequest request);

        // =========================
        // INCOME STATEMENT (P&L)
        // =========================
        Task<IncomeStatementResponse> GetIncomeStatementAsync(
            Guid? branchId,
            DateTime? fromDate,
            DateTime? toDate);

        // =========================
        // BREAKDOWNS (REPORTING)
        // =========================
        Task<List<ExpenseCategorySummaryResponse>> GetExpenseBreakdownAsync(
            Guid ? branchId,
            DateTime? fromDate,
            DateTime ?toDate);

        Task<List<RevenueSummaryResponse>> GetRevenueBreakdownAsync(
            Guid ? branchId,
            DateTime? fromDate,
            DateTime? toDate);


        // =========================
        // UI 1: DEPOSIT (ADD MONEY)
        // =========================

        /// <summary>
        /// Select customer + amount + remark
        /// Increases wallet balance
        /// </summary>
        Task DepositAsync(
            Guid customerId,
            decimal amount,
            string remark);

        // =========================
        // UI 2: WALLET TRANSACTION
        // =========================

        /// <summary>
        /// Select wallet + amount + transaction type + remark
        /// Purchase / OwnerUse  => reduce
        /// Refund / OwnerReturn => increase
        /// </summary>
        Task WalletTransactionAsync(
            Guid customerId,
            decimal amount,
            string transactionType,
            string remark);


        /// <summary>
        /// Wallet list (Customer + Balance only)
        /// Filter by phone and date
        /// </summary>
        Task<List<CustomerWalletSimpleResponse>> GetAllWalletCustomersAsync(
            string? phone,
            DateTime? fromDate,
            DateTime? toDate);

        // =========================
        // PAPER VIEW (HEADER + DETAILS)
        // =========================

        /// <summary>
        /// Paper-style customer wallet view
        /// Header (name, phone, balance)
        /// + Detail transactions
        /// </summary>
        Task<CustomerTransactionPaperResponse> GetCustomerTransactionPaperAsync(
            Guid customerId,
            DateTime? fromDate,
            DateTime? toDate);














    }
}
