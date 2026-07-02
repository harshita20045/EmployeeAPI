using System.Reflection.Metadata.Ecma335;
using Azure;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using Grpc.Core;

namespace EmployeeAPI.Grpc.Services
{
    public class DepartmentGrpcService : DepartmentGrpc.DepartmentGrpcBase
    {
        private readonly IDepartmentService _department;

        public DepartmentGrpcService(IDepartmentService department)
        {
            _department = department;
        }
        public override async Task<GetDepartmentResponse> CreateDepartment(CreateDepartmentRequest request, ServerCallContext context)
        {


            var department = await _department.AddDepartment(new Application.DTOs.AddDepartmentDto
            {
                Name = request.Name
            });

            return new GetDepartmentResponse { Name = department.Name };
        }

        public override async Task<GetDepartmentResponse> GetDepartmentById(GetDepartmentByIdRequest request, ServerCallContext context)
        {
            var department = await _department.GetDepartmentById(request.Id);
            return new GetDepartmentResponse
            {
                Name = department.Name
            };
        }

        public override async Task<GetDepartmentResponse> UpdateDepartment(UpdateDepartmentRequest request, ServerCallContext context)
        {
            var department = await _department.UpdateDepartment(new Application.DTOs.UpdateDepartmentDto
            {
                Id = request.Id,
                Name = request.Name
            });

            return new GetDepartmentResponse
            {
                Name = department.Name
            };
        }

        public override async Task<DeleteDepartmentResponse> DeleteDepartment(DeleteDepartmentRequest request, ServerCallContext context)
        {
            var result = await _department.DeleteDepartment(request.Id);
            return new DeleteDepartmentResponse
            {
                Result = result
            };
        }
        public override async Task<GetAllDepartmentResponse> GetAllDepartment(Empty request, ServerCallContext context)
        {
            var departments = await _department.GetAllDepartments();
            var response = new GetAllDepartmentResponse();
            response.Departments.AddRange(departments.Select(d => new GetDepartmentResponse
            {
                Name = d.Name
            }));

            return response;

        }

        public override async Task<GetEmployeeInDepartmentResponse> GetEmployeeInDepartment(GetEmployeeInDepartmentRequest request, ServerCallContext context)
        {
            var employees = await _department.GetEmployeeInDepartment(request.Id);
            var response = new GetEmployeeInDepartmentResponse();
            response.Employees.AddRange(employees.Select(e => new GetEmployeeResponseDepartment
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email

            }));
            return response;
        }



    }
}
