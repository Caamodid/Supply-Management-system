using Application.Common.Request;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands
{
    public class EditSaleCommand
            : IRequest<IResponseWrapper<string>>, IValidateMe
    {
        public EditSaleRequest Request { get; set; } = default!;
    }

    public class EditSaleCommandHandler
       : IRequestHandler<EditSaleCommand, IResponseWrapper<string>>
    {
        private readonly ISalesService _salesService;

        public EditSaleCommandHandler(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IResponseWrapper<string>> Handle(
            EditSaleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _salesService.EditSaleAsync(request.Request);

                return await ResponseWrapper<string>
                    .SuccessAsync("Sale updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<string>
                    .FailureAsync(ex.Message, "Failed to edit sale.");
            }
        }
    }

}
