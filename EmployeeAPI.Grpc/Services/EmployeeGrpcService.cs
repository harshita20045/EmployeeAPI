using EmployeeAPI.Grpc;
using Grpc.Core;
using EmployeeAPI.Application.Interfaces;

namespace EmployeeAPI.Grpc.Services
{
    public class EmployeeGrpcService : EmployeeGrpc.EmployeeGrpcBase
    {
        private readonly IEmployeeService _service;

        public EmployeeGrpcService(IEmployeeService service)
        {
            _service = service;
        }

        public override async Task<GetAllEmployeeResponse> GetEmployee(EmptyRequest request, ServerCallContext context)
        {
            var employees = await _service.GetAllEmployees();

            var response = new GetAllEmployeeResponse();

            response.Employees.AddRange(employees.Select(p => new GetEmployeeResponse
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email
            }));

            return response;
        }

        public override async Task<GetEmployeeResponse> GetEmployeeById(GetEmployeeByIdRequest request, ServerCallContext context)
        {
            var employee = await _service.GetEmployeeById(request.Id);

            if (employee == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Employee not found"));

            var response = new GetEmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };

            return response;
        }

        public override async Task<GetEmployeeResponse> CreateEmployee(CreateEmployeeRequest request, ServerCallContext context)
        {
            var employee = new Application.DTOs.AddEmployeeInput
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DepartmentId = request.DepartmentId,
            };

            var result = await _service.AddEmployee(employee);

            return new GetEmployeeResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email
            };
        }

        public override async Task<GetEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest request, ServerCallContext context)
        {
            var employee = new EmployeeAPI.Application.DTOs.UpdateEmployeeDto
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
                
            };

            var result =await _service.UpdateEmployee(employee);

            return new GetEmployeeResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email
            };
        }

        public override async Task<DeleteEmployeeResponse> DeleteEmployee(DeleteEmployeeRequest request, ServerCallContext context)
        {
            var employee = await _service.GetEmployeeById(request.Id);

            if (employee == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Employee not found"));

            var result= await  _service.DeleteEmployee(request.Id);

            return new DeleteEmployeeResponse
            {
                Message = "Employee deleted successfully",
                Result=result
            };
        }

        public override async Task<AssignProjectResponse> AssignProject(AssignProjectRequest request, ServerCallContext context)
        {
            var result = await _service.AssignProject(request.ProjectId, request.EmployeeId);
            return new AssignProjectResponse
            {
                Message = "Assigned Project successfully",
                Result = result
            };
        }
    }
}