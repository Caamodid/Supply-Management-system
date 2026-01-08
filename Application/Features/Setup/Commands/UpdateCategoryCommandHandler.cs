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
    public class UpdateCategoryCommand : IRequest<IResponseWrapper<CategoryResponses>>, IValidateMe
    {
        public UpdateCategoryRequest  updateCategoryRequest { get; set; } = default!;
        public Guid Id { get; set; }
    }
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResponseWrapper<CategoryResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<CategoryResponses>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map DTO to Entity
                var categoryEntity = _mapper.Map<Category>(request.updateCategoryRequest);

                // Update entity
                var updatedCategory = await companyService.UpdateCategoryAsync(request.Id, categoryEntity);

                // Map updated entity to response
                var responseDto = _mapper.Map<CategoryResponses>(updatedCategory);

                return await ResponseWrapper<CategoryResponses>.SuccessAsync(responseDto, "Category updated successfully.");
            }
            catch (Exception ex)
            {
                return await ResponseWrapper<CategoryResponses>.FailureAsync(ex.Message, "Failed to update Category.");
            }
        }
    }


}
