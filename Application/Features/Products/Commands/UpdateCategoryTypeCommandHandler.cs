using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Features.Setup.Commands;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class UpdateCategoryTypeCommand : IRequest<IResponseWrapper<CategoryTypeResponses>>, IValidateMe
    {
        public Guid Id { get; set; }
        public UpdateCategoryTypeRequest  updateCategoryType { get; set; } = default!;
    }


    public class UpdateCategoryTypeCommandHandler : IRequestHandler<UpdateCategoryTypeCommand, IResponseWrapper<CategoryTypeResponses>>
    {
        private readonly IProductService  productService;
        private readonly IMapper _mapper;
        public UpdateCategoryTypeCommandHandler(IProductService  _productService, IMapper mapper)
        {
            productService = _productService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<CategoryTypeResponses>> Handle(UpdateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map DTO to Entity
                var categoryTypeEntity = _mapper.Map<CategoryType>(request.updateCategoryType);

                // Update entity
                var updatedbranch = await productService.UpdateCategoryTypeAsync(request.Id, categoryTypeEntity);

                // Map updated entity to response
                var responseDto = _mapper.Map<CategoryTypeResponses>(updatedbranch);

                return await ResponseWrapper<CategoryTypeResponses>.SuccessAsync(responseDto, "categoryType updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CategoryTypeResponses>.FailureAsync(ex.Message, "Failed to update categoryType.");
            }
        }
    }

}
