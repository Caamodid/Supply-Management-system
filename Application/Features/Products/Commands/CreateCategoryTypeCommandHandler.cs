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
    public class CreateCategoryTypeCommand : IRequest<IResponseWrapper<CategoryTypeResponses>>, IValidateMe
    {
        public CreateCategoryTypeRequest  createCategoryTypeRequest { get; set; } = default!;

    }

    public class CreateCategoryTypeCommandHandler : IRequestHandler<CreateCategoryTypeCommand, IResponseWrapper<CategoryTypeResponses>>
    {
        private readonly IProductService  _productService;
        private readonly IMapper _mapper;
        public CreateCategoryTypeCommandHandler(IProductService  productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<CategoryTypeResponses>> Handle(CreateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Entity
                var categoryTypeEntity = _mapper.Map<CategoryType>(request.createCategoryTypeRequest);
                // 2️⃣ Save entity
                var createdCategoryType = await _productService.CreateCategoryTypeAsync(categoryTypeEntity);
                // 3️⃣ Map back Entity → Response DTO
                var responseDto = _mapper.Map<CategoryTypeResponses>(createdCategoryType);
                // 4️⃣ Return standardized success response
                return await ResponseWrapper<CategoryTypeResponses>.SuccessAsync(responseDto, "CategoryType created successfully.");
            }
            catch (Exception ex)
            {
                // 5️⃣ Handle and wrap any unexpected error
                return await ResponseWrapper<CategoryTypeResponses>.FailureAsync(ex.Message, "Failed to create CategoryType.");
            }
        }
    }

}
