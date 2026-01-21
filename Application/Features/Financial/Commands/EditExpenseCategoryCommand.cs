using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Commands.EditExpenseCategory
{
    public class EditExpenseCategoryCommand
        : IRequest<IResponseWrapper<ExpenseCategory>>
    {
        public EditExpenseCategoryRequest Request { get; set; } = default!;
    }

    public class EditExpenseCategoryCommandHandler
        : IRequestHandler<EditExpenseCategoryCommand, IResponseWrapper<ExpenseCategory>>
    {
        private readonly IFinancialReportService _financialService;

        public EditExpenseCategoryCommandHandler(
            IFinancialReportService financialService)
        {
            _financialService = financialService;
        }

        public async Task<IResponseWrapper<ExpenseCategory>> Handle(
            EditExpenseCategoryCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _financialService
                    .EditExpenseCategoryAsync(request.Request);

                return await ResponseWrapper<ExpenseCategory>
                    .SuccessAsync(result, "Expense category updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<ExpenseCategory>
                    .FailureAsync(ex.Message, "Failed to update expense category.");
            }
        }
    }
}
