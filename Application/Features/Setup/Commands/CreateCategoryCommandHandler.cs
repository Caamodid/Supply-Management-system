using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
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

namespace Application.Features.Setup.Commands
{
    public class CreateCategoryCommand : IRequest<IResponseWrapper<CategoryResponses>>, IValidateMe
    {

        public CreateCategoryRequest  createCategoryRequest { get; set; } = default!;

    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResponseWrapper<CategoryResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }
        public async Task<IResponseWrapper<CategoryResponses>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Entity
                var cateoryEntity = _mapper.Map<Category>(request.createCategoryRequest);
                // 2️⃣ Save entity
                var createdCategory = await companyService.CreateCategoryAsync(cateoryEntity);
                // 3️⃣ Map back Entity → Response DTO
                var responseDto = _mapper.Map<CategoryResponses>(createdCategory);
                // 4️⃣ Return standardized success response
                return await ResponseWrapper<CategoryResponses>.SuccessAsync(responseDto, "Category created successfully.");
            }
            catch (Exception ex)
            {
                // 5️⃣ Handle and wrap any unexpected error
                return await ResponseWrapper<CategoryResponses>.FailureAsync(ex.Message, "Failed to create Category.");
            }
        }
    }

}
