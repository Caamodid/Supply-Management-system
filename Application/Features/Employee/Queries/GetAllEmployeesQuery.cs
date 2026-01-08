using Application.Common.Response;
using Application.Common.Wrapper;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries
{

    public class GetAllEmployeesQuery : IRequest<IResponseWrapper<List<EmployeeResponse>>>
    {
    }
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IResponseWrapper<List<EmployeeResponse>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<List<EmployeeResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Fetch all employees from the repository
                var employees = await _employeeRepository.GetAllAsync();

                // 2️⃣ Map to DTO list
                var mappedEmployees = _mapper.Map<List<EmployeeResponse>>(employees);

                // 3️⃣ Check if list is empty
                if (mappedEmployees.Count == 0)
                {
                    return await ResponseWrapper<List<EmployeeResponse>>.SuccessAsync( new List<EmployeeResponse>(),"No employees found.",200
                    );
                }

                // 4️⃣ Return standardized success response
                return await ResponseWrapper<List<EmployeeResponse>>.SuccessAsync(mappedEmployees, "Employees retrieved successfully.",200
                );
            }
            catch (System.Exception ex)
            {
                // 5️⃣ Handle unexpected errors gracefully
                return await ResponseWrapper<List<EmployeeResponse>>.FailureAsync( ex.Message,"An error occurred while retrieving employees.",500
                );
            }
        }
    }
}
