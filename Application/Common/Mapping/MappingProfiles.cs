using Application.Common.Request;
using Application.Common.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    /// <summary>
    /// Central AutoMapper profile for mapping between Entities, DTOs, and Requests.
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // =========================================================
            // EMPLOYEE MAPPINGS
            // =========================================================

            //  CreateEmployeeRequest → Employees (for creation)
            CreateMap<CreateRequestEmployee, Employees>();

            // UpdateEmployeeRequest → Employees (for update)
            CreateMap<UpdateEmployeeRequest, Employees>();

            //  Employees → EmployeeResponse (for read/query)
            CreateMap<Employees, EmployeeResponse>();



            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyResponses>();



            CreateMap<CreateBranchRequest, Branch>();
            CreateMap<UpdateBranchRequest, Branch>();
            CreateMap<Branch, BranchResponses>();

            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, CategoryResponses>();



            CreateMap<CreateCategoryTypeRequest, CategoryType>();
            CreateMap<UpdateCategoryTypeRequest, CategoryType>();
            CreateMap<CategoryType, CategoryTypeResponses>();


            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductResponses>();



            // (Optional) ReverseMap if needed for bidirectional mapping:
            // CreateMap<Employees, EmployeeResponse>().ReverseMap();
        }
    }
}
