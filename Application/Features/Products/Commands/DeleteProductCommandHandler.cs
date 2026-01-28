using Application.Common.Wrapper;
using Application.Features.Setup.Commands;
using Application.Interfaces;
using Application.Pipelines;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<IResponseWrapper<Guid>>, IValidateMe
    {
        public Guid Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResponseWrapper<Guid>>
    {
        private readonly IProductService  _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;

        }

        public async Task<IResponseWrapper<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedId = await _productService.DeleteProdAsync(request.Id);
                return await ResponseWrapper<Guid>.SuccessAsync(default, "Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<Guid>.FailureAsync(ex.Message, "Fauled to delete Product.");
            }
        }
    }

}
