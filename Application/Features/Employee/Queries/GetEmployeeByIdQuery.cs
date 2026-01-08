using Application.Common.Response;
using Application.Common.Wrapper;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries
{
    /// <summary>
    /// Query to retrieve a single employee by their unique identifier.
    /// </summary>
    public class GetEmployeeByIdQuery : IRequest<IResponseWrapper<EmployeeResponse>>
    {
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Handles the logic for retrieving an employee by ID.
    /// </summary>
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, IResponseWrapper<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<EmployeeResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Retrieve the employee from the repository
                var employee = await _employeeRepository.GetByIdAsync(request.Id);

                // 2️⃣ If found, map to DTO and return success
                if (employee is not null)
                {
                    var mappedEmployee = _mapper.Map<EmployeeResponse>(employee);
                    return await ResponseWrapper<EmployeeResponse>.SuccessAsync(
                        mappedEmployee,
                        "Employee retrieved successfully.",
                        200
                    );
                }

                // 3️⃣ If not found, return a standardized not found response
                return await ResponseWrapper<EmployeeResponse>.FailureAsync(
                    "Employee does not exist.",
                    "Not Found.",
                    404
                );
            }
            catch (Exception ex)
            {
                // 4️⃣ Handle any unexpected error gracefully
                return await ResponseWrapper<EmployeeResponse>.FailureAsync(
                    ex.Message,
                    "An error occurred while retrieving the employee.",
                    500
                );
            }
        }
    }
}
