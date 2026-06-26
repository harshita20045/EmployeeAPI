using EmployeeAPI.Grpc;
using Grpc.Core;
using EmployeeAPI.Application.Interfaces;

namespace EmployeeAPI.Grpc.Services
{
    public class EmployeeGrpcService : EmployeeAPI.EmployeeAPIBase
    {
        private readonly IEmployeeService _service;

        public EmployeeGrpcService(IEmployeeService service)
        {
            _service = service;
        }

        public override Task<GetAllEmployeeResponse> GetEmployee(Empty request, ServerCallContext context)
        {
            var employees = _service.GetAllEmployees();

            var response = new GetAllEmployeeResponse();

            response.Employees.AddRange(employees.Select(p => new GetEmployeeResponse
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email
            }));

            return Task.FromResult(response);
        }

        public override Task<GetEmployeeResponse> GetEmployeeById(GetEmployeeByIdRequest request, ServerCallContext context)
        {
            var employee = _service.GetEmployeeById(request.Id);

            if (employee == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Employee not found"));

            var response = new GetEmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };

            return Task.FromResult(response);
        }

        public override Task<GetEmployeeResponse> CreateEmployee(CreateEmployeeRequest request, ServerCallContext context)
        {
            var employee = new Domain.Entities.Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            var result = _service.AddEmployee(employee);

            return Task.FromResult(new GetEmployeeResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email
            });
        }

        public override Task<GetEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest request, ServerCallContext context)
        {
            var employee = new Domain.Entities.Employee
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            var result = _service.UpdateEmployee(employee);

            return Task.FromResult(new GetEmployeeResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email
            });
        }

        public override Task<DeleteEmployeeResponse> DeleteEmployee(DeleteEmployeeRequest request, ServerCallContext context)
        {
            var employee = _service.GetEmployeeById(request.Id);

            if (employee == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Employee not found"));

            _service.DeleteEmployee(employee);

            return Task.FromResult(new DeleteEmployeeResponse
            {
                Message = "Employee deleted successfully"
            });
        }
    }
}