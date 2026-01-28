using Application.Common.Wrapper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Financial.Commands
{
    public class WalletTransactionCommand : IRequest<IResponseWrapper<string>>
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
    }

    public class WalletTransactionCommandHandler
        : IRequestHandler<WalletTransactionCommand, IResponseWrapper<string>>
    {
        private readonly IFinancialReportService  _financialReportService;

        public WalletTransactionCommandHandler(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        public async Task<IResponseWrapper<string>> Handle(
            WalletTransactionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _financialReportService.WalletTransactionAsync(
                    request.CustomerId,
                    request.Amount,
                    request.TransactionType,
                    request.Remark);

                return await ResponseWrapper<string>
                    .SuccessAsync(
                        "Wallet transaction completed successfully.",
                        "Customer wallet updated.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<string>
                    .FailureAsync(
                        ex.Message,
                        "Failed to process wallet transaction.");
            }
        }
    }
}
