using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Pipelines;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands
{
    /// <summary>
    /// Command for updating an existing employee.
    /// </summary>
    public class UpdateEmployeeCommand : IRequest<IResponseWrapper<EmployeeResponse>>, IValidateMe
    {
        public UpdateEmployeeRequest UpdateEmployeeRequest { get; set; } = null!;
    }

    /// <summary>
    /// Handles the employee update logic.
    /// </summary>
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, IResponseWrapper<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IResponseWrapper<EmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Find the existing employee
                var employee = await _employeeRepository.GetByIdAsync(request.UpdateEmployeeRequest.Id);
                if (employee == null)
                {
                    return await ResponseWrapper<EmployeeResponse>.FailureAsync(
                        "Employee not found.",
                        "Update failed.",
                        404
                    );
                }

                // 2️⃣ Map updated fields from DTO → existing entity
                _mapper.Map(request.UpdateEmployeeRequest, employee);

                // 3️⃣ Persist the changes
                await _employeeRepository.UpdateAsync(employee);

                // 4️⃣ Map entity → response DTO
                var responseDto = _mapper.Map<EmployeeResponse>(employee);

                // 5️⃣ Return success response
                return await ResponseWrapper<EmployeeResponse>.SuccessAsync(
                    responseDto,
                    "Employee updated successfully.",
                    200
                );
            }
            catch (Exception ex)
            {
                // 6️⃣ Handle and wrap unexpected errors
                return await ResponseWrapper<EmployeeResponse>.FailureAsync(
                    ex.Message,
                    "An error occurred while updating the employee.",
                    500
                );
            }
        }
    }
}
