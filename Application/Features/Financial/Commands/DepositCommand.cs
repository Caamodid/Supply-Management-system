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
    public class DepositCommand : IRequest<IResponseWrapper<string>>
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; } = string.Empty;
    }

    public class DepositCommandHandler
       : IRequestHandler<DepositCommand, IResponseWrapper<string>>
    {
        private readonly IFinancialReportService  _financialReportService;

        public DepositCommandHandler(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        public async Task<IResponseWrapper<string>> Handle(
            DepositCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _financialReportService.DepositAsync(
                    request.CustomerId,
                    request.Amount,
                    request.Remark);

                return await ResponseWrapper<string>
                    .SuccessAsync(
                        "Deposit completed successfully.",
                        "Customer wallet updated.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<string>
                    .FailureAsync(
                        ex.Message,
                        "Failed to deposit amount.");
            }
        }
    }
}
