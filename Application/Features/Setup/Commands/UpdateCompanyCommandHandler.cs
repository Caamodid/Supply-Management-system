using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Features.Setup.Commands
{
    public class UpdateCompanyCommand : IRequest<IResponseWrapper<CompanyResponses>>, IValidateMe
    {
        public UpdateCompanyRequest updateCompanyRequest { get; set; } = default!;
        public Guid Id { get; set; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, IResponseWrapper<CompanyResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        private readonly string _logoUploadPath;

        public UpdateCompanyCommandHandler(ICompanyService companyService, IMapper mapper, IHostEnvironment environment)
        {
            this.companyService = companyService;
            _mapper = mapper;

            // Path to save logos
            _logoUploadPath = Path.Combine(environment.ContentRootPath, "wwwroot", "uploads", "logos");
            if (!Directory.Exists(_logoUploadPath))
            {
                Directory.CreateDirectory(_logoUploadPath);
            }
        }

        public async Task<IResponseWrapper<CompanyResponses>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // If a new logo is uploaded, save it and update the logo URL
                string logoUrl = string.Empty;

                if (request.updateCompanyRequest.LogoFile != null)
                {
                    logoUrl = await SaveLogoFile(request.updateCompanyRequest.LogoFile);
                }

                // Map request DTO → Entity
                var companyEntity = _mapper.Map<Company>(request.updateCompanyRequest);

                // Set the logo URL if a new logo was uploaded
                if (!string.IsNullOrEmpty(logoUrl))
                {
                    companyEntity.LogoUrl = logoUrl;
                }

                // Update the company entity
                var updatedCompany = await companyService.UpdateCompAsync(request.Id, companyEntity);

                // Map back Entity → Response DTO
                var responseDto = _mapper.Map<CompanyResponses>(updatedCompany);

                // Return standardized success response
                return await ResponseWrapper<CompanyResponses>.SuccessAsync(responseDto, "Company updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle and wrap any unexpected error
                return await ResponseWrapper<CompanyResponses>.FailureAsync(ex.Message, "Failed to update Company.");
            }
        }

        // Method to save the logo file and return the URL
        private async Task<string> SaveLogoFile(IFormFile logoFile)
        {
            var fileExtension = Path.GetExtension(logoFile.FileName);
            var fileName = Guid.NewGuid() + fileExtension; // Unique file name to prevent overwriting
            var filePath = Path.Combine(_logoUploadPath, fileName);

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await logoFile.CopyToAsync(stream);
            }

            // Return the URL to the logo file
            return $"/uploads/logos/{fileName}";
        }
    }
}
