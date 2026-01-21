using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Commands.CreateExpenseCategory
{
    public class CreateExpenseCategoryCommand
        : IRequest<IResponseWrapper<ExpenseCategory>>
    {
        public CreateExpenseCategoryRequest Request { get; set; } = default!;
    }

    public class CreateExpenseCategoryCommandHandler
        : IRequestHandler<CreateExpenseCategoryCommand, IResponseWrapper<ExpenseCategory>>
    {
        private readonly IFinancialReportService _financialService;

        public CreateExpenseCategoryCommandHandler(
            IFinancialReportService financialService)
        {
            _financialService = financialService;
        }

        public async Task<IResponseWrapper<ExpenseCategory>> Handle(
            CreateExpenseCategoryCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _financialService
                    .CreateExpenseCategoryAsync(request.Request);

                return await ResponseWrapper<ExpenseCategory>
                    .SuccessAsync(result, "Expense category created successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<ExpenseCategory>
                    .FailureAsync(ex.Message, "Failed to create expense category.");
            }
        }
    }
}
