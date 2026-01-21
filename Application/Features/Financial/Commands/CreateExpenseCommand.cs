using Application.Common.Request;
using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Financial.Commands.CreateExpense
{
    public class CreateExpenseCommand
        : IRequest<IResponseWrapper<string>>
    {
        public CreateExpenseRequest Request { get; set; } = default!;
    }

    public class CreateExpenseCommandHandler
        : IRequestHandler<CreateExpenseCommand, IResponseWrapper<string>>
    {
        private readonly IFinancialReportService _financialService;

        public CreateExpenseCommandHandler(
            IFinancialReportService financialService)
        {
            _financialService = financialService;
        }

        public async Task<IResponseWrapper<string>> Handle(
            CreateExpenseCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _financialService.CreateExpenseAsync(request.Request);

                return await ResponseWrapper<string>
                    .SuccessAsync("OK", "Expense recorded successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<string>
                    .FailureAsync(ex.Message, "Failed to record expense.");
            }
        }
    }
}
