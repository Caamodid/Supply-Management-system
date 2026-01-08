using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Pipelines;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Employee.Commands
{
    // ============================================================
    // Command: carries input data
    // ============================================================
    public class CreateEmployeeCommand : IRequest<IResponseWrapper<EmployeeResponse>>, IValidateMe
    {
        public CreateRequestEmployee CreateEmployeeRequest { get; set; } = default!;
    }

    // ============================================================
    // Handler: executes business logic
    // ============================================================
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IResponseWrapper<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<EmployeeResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Map request DTO → Entity
                var employeeEntity = _mapper.Map<Employees>(request.CreateEmployeeRequest);

                // 2️⃣ Save entity
                var createdEmployee = await _employeeRepository.AddAsync(employeeEntity);

                // 3️⃣ Map back Entity → Response DTO
                var responseDto = _mapper.Map<EmployeeResponse>(createdEmployee);

                // 4️⃣ Return standardized success response
                return await ResponseWrapper<EmployeeResponse>.SuccessAsync(responseDto, "Employee created successfully.");
            }
            catch (Exception ex)
            {
                // 5️⃣ Handle and wrap any unexpected error
                return await ResponseWrapper<EmployeeResponse>.FailureAsync(ex.Message, "Failed to create employee.", 500);
            }
        }
    }
}
