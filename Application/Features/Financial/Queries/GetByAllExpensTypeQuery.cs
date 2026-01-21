using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Setup.Queries;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Financial.Queries
{
    public class GetByAllExpensTypeQuery : IRequest<IResponseWrapper<List<ExpenseTypeResponse>>>, IValidateMe
    {
    }
    public class GetByAllExpensTypeQueryHandler : IRequestHandler<GetByAllExpensTypeQuery, IResponseWrapper<List<ExpenseTypeResponse>>>
    {
        private readonly IFinancialReportService  _financialReportService;
        private readonly IMapper _mapper;
        public GetByAllExpensTypeQueryHandler(IFinancialReportService financialReportService, IMapper mapper)
        {
            _financialReportService = financialReportService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<ExpenseTypeResponse>>> Handle(GetByAllExpensTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var expensesType = await _financialReportService.GetIExpenseTypeAsync();

                var responseDtos = _mapper.Map<List<ExpenseTypeResponse>>(expensesType);

                return await ResponseWrapper<List<ExpenseTypeResponse>>.SuccessAsync(responseDtos, "expensesType retrieve successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<List<ExpenseTypeResponse>>.FailureAsync(ex.Message, "Failed to get expensesType list.");
            }
        }
    }
}
