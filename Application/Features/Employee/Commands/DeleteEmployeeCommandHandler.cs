using Application.Common.Wrapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands
{
    /// <summary>
    /// Command to delete an employee by ID.
    /// </summary>
    public class DeleteEmployeeCommand : IRequest<IResponseWrapper<Guid>>
    {
        public Guid EmployeeId { get; set; }
    }

    /// <summary>
    /// Handles the DeleteEmployeeCommand logic.
    /// </summary>
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, IResponseWrapper<Guid>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IResponseWrapper<Guid>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1️⃣ Retrieve the employee
                var employeeInDb = await _employeeRepository.GetByIdAsync(request.EmployeeId);

                // 2️⃣ If not found
                if (employeeInDb is null)
                {
                    return await ResponseWrapper<Guid>.FailureAsync(
                        "Employee does not exist.",
                        "Delete failed.",
                        404
                    );
                }

                // 3️⃣ Delete the employee
                await _employeeRepository.DeleteAsync(employeeInDb);

                // 4️⃣ Return standardized success response
                return await ResponseWrapper<Guid>.SuccessAsync(
                    request.EmployeeId,
                    "Employee deleted successfully.",
                    200
                );
            }
            catch (Exception ex)
            {
                // 5️⃣ Catch any unhandled exceptions
                return await ResponseWrapper<Guid>.FailureAsync(
                    ex.Message,
                    "An unexpected error occurred while deleting the employee.",
                    500
                );
            }
        }
    }
}
