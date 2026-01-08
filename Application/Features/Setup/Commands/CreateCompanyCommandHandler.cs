using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Application.Pipelines;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace Application.Features.Setup.Commands
{
    public class CreateCompanyCommand : IRequest<IResponseWrapper<CompanyResponses>>, IValidateMe
    {
        public CreateCompanyRequest createCompanyRequest { get; set; } = default!;
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, IResponseWrapper<CompanyResponses>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;
        private readonly string _logoUploadPath;

        public CreateCompanyCommandHandler(ICompanyService companyService, IMapper mapper, IHostEnvironment environment)
        {
            this.companyService = companyService;
            _mapper = mapper;

            // Setting the path where logos will be saved
            _logoUploadPath = Path.Combine(environment.ContentRootPath, "wwwroot", "uploads", "logos");
            if (!Directory.Exists(_logoUploadPath))
            {
                Directory.CreateDirectory(_logoUploadPath);
            }
        }

        public async Task<IResponseWrapper<CompanyResponses>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Save logo and get the URL
                string logoUrl = string.Empty;

                if (request.createCompanyRequest.LogoFile != null)
                {
                    logoUrl = await SaveLogoFile(request.createCompanyRequest.LogoFile);
                }

                // Map the request DTO to the entity
                var companyEntity = _mapper.Map<Company>(request.createCompanyRequest);

                // Set the Logo URL
                companyEntity.LogoUrl = logoUrl;

                // Save company entity
                var createdCompany = await companyService.CreateCompAsync(companyEntity);

                // Map entity to response DTO
                var responseDto = _mapper.Map<CompanyResponses>(createdCompany);

                // Return success response
                return await ResponseWrapper<CompanyResponses>.SuccessAsync(responseDto, "Company created successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors and return failure response
                return await ResponseWrapper<CompanyResponses>.FailureAsync(ex.Message, "Failed to create Company.");
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
